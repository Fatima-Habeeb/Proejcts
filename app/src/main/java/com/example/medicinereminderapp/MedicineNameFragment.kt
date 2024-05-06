package com.example.medicinereminderapp

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import androidx.fragment.app.Fragment

class MedicineNameFragment : Fragment() {

    private lateinit var onNextClickListener: OnNextClickListener

    interface OnNextClickListener {
        fun onNextClicked(identifier: String, data: String)
    }

    fun setOnNextClickListener(listener: OnNextClickListener) {
        onNextClickListener = listener
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_medicine_name, container, false)

        view.findViewById<Button>(R.id.nextButtonName).setOnClickListener {
            val medicineNameEditText = view.findViewById<EditText>(R.id.medicineNameEditText);
            onNextClickListener.onNextClicked("medicineName", medicineNameEditText.text.toString())
        }

        return view
    }
}