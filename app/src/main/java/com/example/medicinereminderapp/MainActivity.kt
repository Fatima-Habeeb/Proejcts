package com.example.medicinereminderapp

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.MotionEvent
import android.widget.Button
import android.widget.TextView
import androidx.core.content.ContextCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val signupbtn: Button = findViewById(R.id.SignupButton)
        signupbtn.setOnClickListener {
            val fragment = SignupFragment()

            // Get the supportFragmentManager and start a transaction
            val transaction = supportFragmentManager.beginTransaction()

            // Replace the current fragment/container with the new fragment
            transaction.replace(R.id.container, fragment)

            // Add this transaction to the back stack (optional)
            transaction.addToBackStack(null)

            // Commit the transaction
            transaction.commit()
        }

        val loginbtn: Button = findViewById(R.id.LoginButton)
        loginbtn.setOnClickListener {
            val fragment = LoginFragment()

            // Get the supportFragmentManager and start a transaction
            val transaction = supportFragmentManager.beginTransaction()

            // Replace the current fragment/container with the new fragment
            transaction.replace(R.id.container, fragment)

            // Add this transaction to the back stack (optional)
            transaction.addToBackStack(null)

            // Commit the transaction
            transaction.commit()
         }

       /* loginbtn.setOnTouchListener { v, event ->
            when (event.action) {
                MotionEvent.ACTION_UP -> {
                    // If the touch is released, revert the text color to the default color
                    loginbtn.setTextColor(defaultColor)
                    true
                }
                else -> false
            }
        }*/
    }
}