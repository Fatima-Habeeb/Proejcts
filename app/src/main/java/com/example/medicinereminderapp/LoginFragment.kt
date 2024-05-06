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
import android.widget.TextView
import android.widget.Toast
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.DataSnapshot
import com.google.firebase.database.DatabaseError
import com.google.firebase.database.FirebaseDatabase
import com.google.firebase.database.ValueEventListener
import java.util.Date

class LoginFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val view = inflater.inflate(R.layout.fragment_login, container, false)

        val backBtn: Button = view.findViewById(R.id.back_btn)
        backBtn.setOnClickListener {
            // Navigate back to the previous fragment or activity
            requireActivity().onBackPressed()
        }

        val signupbtn: TextView = view.findViewById(R.id.SignupButton)
        signupbtn.setOnClickListener {
            val fragmentB = SignupFragment()
            parentFragmentManager.beginTransaction()
                .replace(R.id.container, fragmentB)
                .addToBackStack(null) // Add transaction to the back stack (optional)
                .commit()
        }

        val userEmail:EditText= view.findViewById(R.id.email_input)
        val userPassword:EditText = view.findViewById(R.id.password_input)

        var loginbtn :Button= view.findViewById(R.id.LoginButton)
        loginbtn.setOnClickListener {
            val email =userEmail.text.toString()
            val password= userPassword.text.toString()
            authenticateUser(email, password)
        }
        return view
    }

    // Function to authenticate user

    private fun authenticateUser(email: String, password: String) {
        val auth: FirebaseAuth = FirebaseAuth.getInstance()
        auth.signInWithEmailAndPassword(email, password)
            .addOnCompleteListener(requireActivity()) { task ->
                if (task.isSuccessful) {
                    val currentUser = auth.currentUser

                    val databaseReference = FirebaseDatabase.getInstance().reference.child("Users")
                        .child(currentUser?.uid ?: "")

                    databaseReference.addListenerForSingleValueEvent(object : ValueEventListener {
                        override fun onDataChange(snapshot: DataSnapshot) {
                            if (snapshot.exists()) {
                                val fullname = snapshot.child("fullname").getValue(String::class.java)
                                val userEmail = snapshot.child("email").getValue(String::class.java)
                                val gender = snapshot.child("gender").getValue(String::class.java)

                                if (fullname != null && userEmail != null && gender != null) {

                                    val bundle = Bundle()
                                    bundle.putString("Fullname", fullname) // Replace "key" with an identifier and "value" with the actual data
                                    bundle.putString("Email", userEmail) // Replace "key" with an identifier and "value" with the actual data
                                    bundle.putString("Gender", gender) // Replace "key" with an identifier and "value" with the actual data
                                    val receiverFragment = ProfileFragment()
                                    receiverFragment.arguments = bundle

                                    parentFragmentManager.beginTransaction()
                                        .replace(R.id.container, receiverFragment) // Use the receiverFragment with arguments
                                        .addToBackStack(null)
                                        .commit()

                                    var medicineDatabaseHelper = MedicineDatabaseHelper(requireContext())

                                    val medicinesSnapshot = snapshot.child("medicines")

                                    for (medicineSnapshot in medicinesSnapshot.children) {
                                        val medicine = Medicine()
                                        medicine.name = medicineSnapshot.child("name").getValue(String::class.java) ?: ""
                                        medicine.xTimes = medicineSnapshot.child("xTimes").getValue(Int::class.java) ?: -1
                                        medicine.startDate = Date(medicineSnapshot.child("startDate").getValue(Long::class.java) ?: 0)
                                        medicine.endDate = Date(medicineSnapshot.child("endDate").getValue(Long::class.java) ?: 0)

                                        // Extract and set the times list
                                        val timesSnapshot = medicineSnapshot.child("times")
                                        for (timeSnapshot in timesSnapshot.children) {
                                            val hour = timeSnapshot.child("hour").getValue(Int::class.java) ?: 0
                                            val minute = timeSnapshot.child("minute").getValue(Int::class.java) ?: 0

                                            val timeModel = TimeModel(hour, minute)
                                            medicine.times.add(timeModel)
                                        }

                                        // Add the medicine to the SQLite database
                                        medicineDatabaseHelper.addMedicine(medicine)
                                    }


                                } else {
                                    // Handle missing user data
                                    Log.e("UserData", "User data missing or incomplete")
                                    Toast.makeText(requireContext(), "User data missing", Toast.LENGTH_SHORT).show()
                                }
                            }
                        }

                        override fun onCancelled(error: DatabaseError) {
                            // Handle database error
                            Log.e("DatabaseError", "Error: ${error.message}")
                            Toast.makeText(requireContext(), "Database error", Toast.LENGTH_SHORT).show()
                        }
                    })

                    Toast.makeText(requireContext(), "Authentication successful.", Toast.LENGTH_SHORT).show()
                } else {
                    // Handle authentication failure
                    Log.e("Authentication", "Failure: ${task.exception?.message}")
                    Toast.makeText(requireContext(), "Authentication failed.", Toast.LENGTH_SHORT).show()
                }
            }
    }


}