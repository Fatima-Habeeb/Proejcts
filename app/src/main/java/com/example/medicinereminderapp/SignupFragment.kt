package com.example.medicinereminderapp

import ProfileFragment
import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.TextView
import android.widget.Toast
import com.google.android.gms.tasks.OnCompleteListener
import com.google.android.gms.tasks.Task
import com.google.firebase.auth.AuthResult
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseUser
import com.google.firebase.database.DatabaseReference
import com.google.firebase.database.FirebaseDatabase

class SignupFragment : Fragment() {

    private lateinit var firstNameInput:EditText
    private lateinit var lastNameInput:EditText
    private lateinit var Gender:String
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val view = inflater.inflate(R.layout.fragment_signup, container, false)

        val backBtn: Button = view.findViewById(R.id.back_btn)
        backBtn.setOnClickListener {
            var intent = Intent(activity, MainActivity::class.java)
            startActivity(intent)
        }

        firstNameInput = view.findViewById(R.id.firstname_input)
        lastNameInput = view.findViewById(R.id.lastname_input)
        var radioGroup: RadioGroup = view.findViewById(R.id.gender_input)


        radioGroup.setOnCheckedChangeListener { _, checkedId ->
            val radioButton: RadioButton = view.findViewById(checkedId)

            // Check which radio button was clicked
            Gender = when (radioButton.id) {
                R.id.radio_male -> "Male"
                R.id.radio_female -> "Female"
                R.id.radio_other -> "Other"
                else -> "" // Handle other cases if needed
            }
        }

        var emailInput:EditText = view.findViewById(R.id.email_input)
        var passwordInput:EditText = view.findViewById(R.id.password_input)
        var confirmPasswordInput:EditText = view.findViewById(R.id.confirm_password_input)


        var registerbtn:Button = view.findViewById(R.id.RegisterButton)
        registerbtn.setOnClickListener {
            val firstName = firstNameInput.text.toString()
            val lastName = lastNameInput.text.toString()
            val email = emailInput.text.toString()
            val password = passwordInput.text.toString()
            val confirmPassword = confirmPasswordInput.text.toString()

            // Email validation pattern
            val emailPattern = "[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+"

            // Validate required fields and email format
            if (firstName.isBlank() || lastName.isBlank() || email.isBlank() ||
                password.isBlank() || confirmPassword.isBlank()
            ) {
                Toast.makeText(activity, "All fields are required", Toast.LENGTH_SHORT).show()
            } else if (!email.matches(emailPattern.toRegex())) {
                Toast.makeText(activity, "Invalid email format", Toast.LENGTH_LONG).show()
            } else if (password != confirmPassword) {
                Toast.makeText(activity, "Password doesn't match with confirm password", Toast.LENGTH_LONG).show()
            } else {
                registerUser(email, password)
            }
        }

        val loginbtn: TextView = view.findViewById(R.id.LoginButton)
        loginbtn.setOnClickListener {
            val fragmentB = LoginFragment()
            parentFragmentManager.beginTransaction()
                .replace(R.id.container, fragmentB)
                .addToBackStack(null)
                .commit()
        }
        return view
    }

    private fun registerUser(email: String, password: String) {
        val auth: FirebaseAuth = FirebaseAuth.getInstance()
        auth.createUserWithEmailAndPassword(email, password)
            .addOnCompleteListener(requireActivity()) { task ->
                if (task.isSuccessful) {
                    val user: FirebaseUser? = auth.currentUser
                    if (user != null) {
                        val userId = user.uid // Get the UID of the registered user

                        val firstName = firstNameInput.text.toString()
                        val lastName = lastNameInput.text.toString()
                        val gender = Gender

                        // Create a reference to "Users" in the Realtime Database
                        val databaseReference = FirebaseDatabase.getInstance().getReference("Users")

                        // Store user data with the same UID as the key in the database
                        val userData = User("$firstName $lastName", gender, email)
                        databaseReference.child(userId).setValue(userData)
                            .addOnCompleteListener { dbTask ->
                                if (dbTask.isSuccessful) {
                                   // submitUserData(userData)
                                    /*Log.d("Registration", "${user.email} successfully registered.")
                                    Toast.makeText(activity, "Registration successful.", Toast.LENGTH_SHORT).show()
*/                                  val bundle = Bundle()
                                    bundle.putString("Fullname", userData.fullname) // Replace "key" with an identifier and "value" with the actual data
                                    bundle.putString("Email", userData.email) // Replace "key" with an identifier and "value" with the actual data
                                    bundle.putString("Gender", userData.gender) // Replace "key" with an identifier and "value" with the actual data
                                    val receiverFragment = ProfileFragment()
                                    receiverFragment.arguments = bundle

                                    parentFragmentManager.beginTransaction()
                                        .replace(R.id.container, receiverFragment) // Use the receiverFragment with arguments
                                        .addToBackStack(null)
                                        .commit()
                                } else {
                                    Log.e("Registration", "Error storing data: ${dbTask.exception?.message}")
                                    Toast.makeText(activity, "Registration failed: ${dbTask.exception?.message}", Toast.LENGTH_LONG).show()
                                }
                            }
                    }
                } else {
                    Log.e("Registration", "Failure: ${task.exception?.message}")
                    Toast.makeText(activity, "Registration failed: ${task.exception?.message}", Toast.LENGTH_LONG).show()
                }
            }
    }


    private fun submitUserData(user: User) {
        val activity = activity

        val database = FirebaseDatabase.getInstance().reference.child("Users")

        val userData = mapOf(
            "fullname" to user.fullname,
            "gender" to user.gender,
            "email" to user.email
        )

        val userReference = database.push()
        val userKey = userReference.key

        userKey?.let {
            userReference.setValue(userData)
                .addOnCompleteListener { task ->
                    if (!task.isSuccessful) {
                        Log.e("firebase", "Error storing data", task.exception)
                        activity?.let {
                            Toast.makeText(it, "Data not stored", Toast.LENGTH_SHORT).show()
                        }
                    } else {
                        /*activity?.let {
                            Toast.makeText(it, "Your data is stored", Toast.LENGTH_SHORT).show()
                        }*/
                        val bundle = Bundle()
                        bundle.putString("Fullname", user.fullname) // Replace "key" with an identifier and "value" with the actual data
                        bundle.putString("Email", user.email) // Replace "key" with an identifier and "value" with the actual data
                        bundle.putString("Gender", user.gender) // Replace "key" with an identifier and "value" with the actual data
                        val receiverFragment = ProfileFragment()
                        receiverFragment.arguments = bundle
                    }
                }
        }
    }
}