package com.example.medicinereminderapp

class User(var fullname:String, var gender:String, var email:String,
           var medicines: MutableList<Medicine> = mutableListOf()){

    fun addMedicine(medicine: Medicine) {
        medicines.add(medicine)
    }
}