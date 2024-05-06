package com.example.medicinereminderapp

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.DatePicker
import android.widget.TextView
import androidx.fragment.app.Fragment
import java.util.Calendar

class MedicineDurationFragment() : Fragment() {

    private lateinit var onNextClickListener: OnNextClickListener
    private var dates: String = ""
    private var cur: Int = 1

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
        val view = inflater.inflate(R.layout.fragment_medicine_duration, container, false)
        var datePicker = view.findViewById<DatePicker>(R.id.datePicker)
        val cal = Calendar.getInstance()
        datePicker.updateDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH))
        var textView = view.findViewById<TextView>(R.id.labelDates)
        view.findViewById<Button>(R.id.nextButtonDates).setOnClickListener {
            val year = datePicker.year
            val month = datePicker.month + 1 // Month is 0-based
            val dayOfMonth = datePicker.dayOfMonth

            val date = "$year-$month-$dayOfMonth"

            if (cur == 1) {
                dates += date
                textView.text = "Enter end date:"
            } else if (cur == 2) {
                dates += ",$date"
                onNextClickListener.onNextClicked("medicineDuration", dates)
            }
            cur++
            val cal = Calendar.getInstance()
            datePicker.updateDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH))
        }

        return view
    }
}