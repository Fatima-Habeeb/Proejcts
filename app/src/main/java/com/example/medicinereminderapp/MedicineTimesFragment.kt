package com.example.medicinereminderapp

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.TimePicker
import androidx.fragment.app.Fragment
import java.util.Calendar

class MedicineTimesFragment(private val xTimes : Int) : Fragment() {

    private lateinit var onNextClickListener: OnNextClickListener
    private var times: String = ""
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
        val view = inflater.inflate(R.layout.fragment_medicine_times, container, false)
        var timePicker = view.findViewById<TimePicker>(R.id.timePicker)
        timePicker.setIs24HourView(true)
        var textView = view.findViewById<TextView>(R.id.labelTimes)
        view.findViewById<Button>(R.id.nextButtonTimes).setOnClickListener {
            val hour = timePicker.hour
            val minute = timePicker.minute
            if(cur == 1)
            {
                times = "$hour:$minute"
            }
            else if(cur == 2)
            {
                times += ",$hour:$minute"
            }
            else if(cur == 3)
            {
                times += ",$hour:$minute"
            }
            if(cur == xTimes)
            {
                onNextClickListener.onNextClicked("medicineTimes", times)
                return@setOnClickListener
            }
            if(cur == 1)
            {
                textView.setText("Enter time for second dose:")
            }
            else if(cur == 2)
            {
                textView.setText("Enter time for third dose:")
            }
            cur++
            val cal = Calendar.getInstance()
            val currentHour = cal.get(Calendar.HOUR_OF_DAY)
            val currentMinute = cal.get(Calendar.MINUTE)
            timePicker.hour = currentHour
            timePicker.minute = currentMinute
        }

        return view
    }
}