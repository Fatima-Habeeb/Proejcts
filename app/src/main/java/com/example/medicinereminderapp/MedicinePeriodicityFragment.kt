package com.example.medicinereminderapp

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.RadioButton
import android.widget.RadioGroup
import androidx.fragment.app.Fragment

class MedicinePeriodicityFragment : Fragment() {

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
        val view = inflater.inflate(R.layout.fragment_medicine_periodicity, container, false)

        val onceADayRadioButton = view.findViewById<RadioButton>(R.id.onceADayRadioButton)
        val twiceADayRadioButton = view.findViewById<RadioButton>(R.id.twiceADayRadioButton)
        val threeTimesADaysRadioButton = view.findViewById<RadioButton>(R.id.threeTimesADayRadioButton)
        val timesRadioGroup = view.findViewById<RadioGroup>(R.id.periodicityRadioGroup)

        view.findViewById<Button>(R.id.nextButtonPeriodicty).setOnClickListener {
            val periodicity = when {
                onceADayRadioButton.isChecked -> "1"
                twiceADayRadioButton.isChecked -> "2"
                threeTimesADaysRadioButton.isChecked -> "3"
                else -> ""
            }

            onNextClickListener.onNextClicked("medicinePeriodicity", periodicity)
        }

        return view
    }
}