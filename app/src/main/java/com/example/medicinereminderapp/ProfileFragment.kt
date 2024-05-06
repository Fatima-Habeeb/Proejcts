import android.app.Dialog
import android.content.DialogInterface
import android.content.Intent
import android.os.Bundle
import android.os.Handler
import android.view.Gravity
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import com.bumptech.glide.Glide
import com.bumptech.glide.load.resource.bitmap.CircleCrop
import com.bumptech.glide.request.RequestOptions
import com.example.medicinereminderapp.MainActivity
import com.example.medicinereminderapp.R
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseUser
import com.google.firebase.database.FirebaseDatabase

class ProfileFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_profile, container, false)

       /* val imageView: ImageView = findViewById(R.id.profile_image)
        val imageUrl = R.drawable.background
        // Load image with Glide and apply circular transformation
        Glide.with(this)
            .load(imageUrl)
            .apply(RequestOptions.bitmapTransform(CircleCrop()))
            .placeholder(R.drawable.background) // Placeholder if the image is not loaded yet
            .into(imageView)
*/
        val fullname = arguments?.getString("Fullname")
        val email = arguments?.getString("Email")
        val gender = arguments?.getString("Gender")

        var usernameText:TextView = view.findViewById(R.id.user_name_text)
        usernameText.setText(fullname.toString())

        var emailText:TextView = view.findViewById(R.id.email_text)
        emailText.setText(email.toString())

        var editButton:Button = view.findViewById(R.id.edit_btn)
        editButton.setOnClickListener {
            showChangeNameDialog(fullname.toString())
        }


        val changePassButton: Button = view.findViewById(R.id.changePassButton)
        changePassButton.setOnClickListener {
            val user = FirebaseAuth.getInstance().currentUser
            user?.email?.let { email -> resetPassword(email) }
        }

        val logoutButton:Button = view.findViewById(R.id.logoutButton)
        logoutButton.setOnClickListener {
            val auth = FirebaseAuth.getInstance()
            auth.signOut()

            // Navigate back to the main activity
            val intent = Intent(requireActivity(), MainActivity::class.java)
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK)
            requireActivity().startActivity(intent)
            requireActivity().finish()
        }



        val deleteButton: Button = view.findViewById(R.id.deleteButton)
        deleteButton.setOnClickListener {
            showConfirmationDialog()
        }

        return view
    }
    private fun showChangeNameDialog(fullname:String) {
        val dialog = Dialog(requireContext())
        dialog.setContentView(R.layout.dialog_change_name)

        val newNameEditText: EditText = dialog.findViewById(R.id.editTextNewName)
        val saveButton: Button = dialog.findViewById(R.id.buttonSave)

        // Retrieve the current name from Firebase or your model
        val currentName = fullname // Replace this with your current name retrieval logic

        newNameEditText.setText(currentName)

        saveButton.setOnClickListener {
            val newName = newNameEditText.text.toString().trim()
            if (newName.isNotEmpty()) {
                // Update the name in Firebase or your model here
                // For Firebase Realtime Database:
                 val userId = FirebaseAuth.getInstance().currentUser?.uid
                val databaseReference = FirebaseDatabase.getInstance().reference.child("Users").child(userId.toString())
                databaseReference.child("fullname").setValue(newName)

                // After updating the name, dismiss the dialog
                dialog.dismiss()

                // Optionally, update the UI with the new name
                // updateUIWithNewName(newName)
            } else {
                // Notify the user to enter a name
                Toast.makeText(requireContext(), "Please enter a name", Toast.LENGTH_SHORT).show()
            }
        }

        dialog.show()
    }


    private fun resetPassword(email: String) {
        val auth: FirebaseAuth = FirebaseAuth.getInstance()
        auth.sendPasswordResetEmail(email)
            .addOnCompleteListener { task ->
                if (task.isSuccessful) {
                    showCustomPopup("Reset link has been sent to your email!")
                } else {
                    showCustomPopup("Failed to send password reset email.")
                }
            }
    }

    private fun showConfirmationDialog() {
        val builder = AlertDialog.Builder(requireContext())
        builder.setTitle("Confirm Deletion")
        builder.setMessage("Are you sure you want to delete your account?")
        builder.setPositiveButton("Yes") { _: DialogInterface, _: Int ->
            deleteUserDataAndAccount()
        }
        builder.setNegativeButton("No") { dialog: DialogInterface, _: Int ->
            dialog.dismiss()
        }
        val dialog: AlertDialog = builder.create()
        dialog.show()
    }

    private fun deleteUserDataAndAccount() {
        val currentUser: FirebaseUser? = FirebaseAuth.getInstance().currentUser
        val userReference = FirebaseDatabase.getInstance().getReference("Users")

        // Retrieve the user's unique ID
        val userId = currentUser?.uid

        // Delete user data from the Realtime Database
        if (userId != null) {
            userReference.child(userId).removeValue()
                .addOnCompleteListener { dataTask ->
                    if (dataTask.isSuccessful) {
                        // If data deletion is successful, proceed to delete the account
                        currentUser.delete().addOnCompleteListener { authTask ->
                            if (authTask.isSuccessful) {
                                val intent = Intent(requireContext(), MainActivity::class.java)
                                startActivity(intent)
                                requireActivity().finish()
                            } else {
                                showCustomPopup("Error in deleting your account!")
                            }
                        }
                    } else {
                        showCustomPopup("Error in deleting your account data!")
                    }
                }
        }
    }


    private fun showCustomPopup(message: String) {
        val dialog = Dialog(requireContext())
        dialog.setContentView(R.layout.popup_layout)

        val window = dialog.window
        window?.setLayout(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT)
        window?.setGravity(Gravity.CENTER)

        dialog.setCanceledOnTouchOutside(true)
        val messageTextView: TextView = dialog.findViewById(R.id.popup_message)
        messageTextView.text = message
        dialog.show()

        val handler = Handler()
        handler.postDelayed({
            dialog.dismiss()
        }, 3000)
    }
}
