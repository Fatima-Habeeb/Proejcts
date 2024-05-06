package com.example.medicinereminderapp

class Utils {
    companion object {
        const val DATABASE_NAME = "MedicineReminderDB"
        const val DATABASE_VERSION = 1

        // Medicine table constants
        const val MEDICINE_TABLE_NAME = "MedicineTable"
        const val MEDICINE_ID_COL = "id"
        const val MEDICINE_NAME_COL = "name"
        const val MEDICINE_X_TIMES_COL = "xTimes"
        const val MEDICINE_START_DATE_COL = "startDate"
        const val MEDICINE_END_DATE_COL = "endDate"

        const val MEDICINE_TIME_TABLE_NAME = "medicine_time_table"
        const val MEDICINE_TIME_ID_COL = "medicine_time_id"
        const val MEDICINE_TIME_HOUR_COL = "medicine_time_hour"
        const val MEDICINE_TIME_MINUTE_COL = "medicine_time_minute"

        // ReportData table constants
        const val REPORT_DATA_TABLE_NAME = "ReportDataTable"
        const val REPORT_DATA_ID_COL = "id"
        const val REPORT_DATA_MEDICINE_NAME_COL = "medicineName"
        const val REPORT_DATA_DATE_TIME_COL = "dateTime"
        const val REPORT_DATA_IS_TAKEN_COL = "isTaken"


    }
}
