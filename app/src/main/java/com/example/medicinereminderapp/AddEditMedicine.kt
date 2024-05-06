package com.example.medicinereminderapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.FirebaseDatabase
import java.text.SimpleDateFormat
import java.util.Date

class AddEditMedicine : AppCompatActivity(),
    MedicineNameFragment.OnNextClickListener,
    MedicineDurationFragment.OnNextClickListener,
    MedicinePeriodicityFragment.OnNextClickListener,
    MedicineTimesFragment.OnNextClickListener{

    private val medicine = Medicine()
    private val auth = FirebaseAuth.getInstance()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_edit_medicine)

        // Initial fragment
        addFragment(MedicineNameFragment())
    }
    private fun addFragment(fragment: Fragment) {
        if (fragment is MedicineNameFragment) {
            fragment.setOnNextClickListener(this)
        } else if (fragment is MedicineDurationFragment) {
            fragment.setOnNextClickListener(this)
        } else if (fragment is MedicinePeriodicityFragment) {
            fragment.setOnNextClickListener(this)
        } else if (fragment is MedicineTimesFragment) {
            fragment.setOnNextClickListener(this)
        }

        val transaction = supportFragmentManager.beginTransaction()
        transaction.replace(R.id.fragmentContainer, fragment)
        transaction.addToBackStack(null)
        transaction.commit()
    }

    override fun onNextClicked(identifier: String, data: String) {
        when (identifier) {
            "medicineName" -> {
                // Save data to the medicine object
                medicine.name = data
                var textBox : TextView = findViewById(R.id.addMedicineTextView)
                textBox.setText(data)
                // Proceed to the next fragment (e.g., MedicineDosageFragment)
                addFragment(MedicineDurationFragment())
            }
            "medicineDuration" -> {
                val dates = data.split(",")
                val format = SimpleDateFormat("yyyy-MM-dd")
                medicine.startDate = format.parse(dates[0]) ?: Date()
                medicine.endDate = format.parse(dates[1]) ?: Date()
                // Proceed to the next fragment
                addFragment(MedicinePeriodicityFragment())
            }
            "medicinePeriodicity" -> {
                // Save data to the medicine object
                medicine.xTimes = data.toInt()
                addFragment(MedicineTimesFragment(medicine.xTimes))
            }
            "medicineTimes" -> {
                // Save data to the medicine object
                val timePairs = data.split(",")

                for (timePair in timePairs) {
                    val hourMinute = timePair.split(":")
                    if (hourMinute.size == 2) {
                        val hour = hourMinute[0].toInt()
                        val minute = hourMinute[1].toInt()
                        val timeModel = TimeModel(hour, minute)
                        medicine.times.add(timeModel)
                    }
                }

                var medDB = MedicineDatabaseHelper(this)

                val currentUser = auth.currentUser
                if (currentUser != null) {
                    val userId = currentUser.uid
                    val userReference = FirebaseDatabase.getInstance().getReference("Users").child(userId)
                    val medicinesReference = userReference.child("medicines")

                    // Generate a unique key for the medicine
                    val medicineKey = medicinesReference.push().key ?: ""

                    // Set the medicine data under the generated key
                    medicinesReference.child(medicineKey).setValue(medicine)
                }

                medDB.addMedicine(medicine)

                var intent = Intent(this,HomeActivity::class.java)
                startActivity(intent)
            }
        }
    }
}