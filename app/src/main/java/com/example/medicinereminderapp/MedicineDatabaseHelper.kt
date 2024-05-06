package com.example.medicinereminderapp

import android.content.ContentValues
import android.content.Context
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import java.util.Calendar
import java.util.Date

class MedicineDatabaseHelper(context: Context) :
    SQLiteOpenHelper(context, Utils.DATABASE_NAME, null, Utils.DATABASE_VERSION) {

    override fun onCreate(db: SQLiteDatabase) {
        val query = ("CREATE TABLE " + Utils.MEDICINE_TABLE_NAME + " ("
                + Utils.MEDICINE_ID_COL + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                Utils.MEDICINE_NAME_COL + " TEXT," +
                Utils.MEDICINE_X_TIMES_COL + " INTEGER," +
                Utils.MEDICINE_START_DATE_COL + " INTEGER," +
                Utils.MEDICINE_END_DATE_COL + " INTEGER" + ")")
        db.execSQL(query)

        val reportDataTableQuery = ("CREATE TABLE " + Utils.REPORT_DATA_TABLE_NAME + " ("
                + Utils.REPORT_DATA_ID_COL + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                Utils.MEDICINE_NAME_COL + " TEXT," +
                Utils.REPORT_DATA_DATE_TIME_COL + " INTEGER," +
                Utils.REPORT_DATA_IS_TAKEN_COL + " INTEGER" + ")")
        db.execSQL(reportDataTableQuery)

        val medicineTimeTableQuery = (
                "CREATE TABLE " + Utils.MEDICINE_TIME_TABLE_NAME + " ("
                        + Utils.MEDICINE_TIME_ID_COL + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                        Utils.MEDICINE_ID_COL + " INTEGER," +
                        Utils.MEDICINE_TIME_HOUR_COL + " INTEGER," +
                        Utils.MEDICINE_TIME_MINUTE_COL + " INTEGER," +
                        "FOREIGN KEY(${Utils.MEDICINE_ID_COL}) REFERENCES ${Utils.MEDICINE_TABLE_NAME}(${Utils.MEDICINE_ID_COL}) ON DELETE CASCADE" +
                        ")"
                )
        db.execSQL(medicineTimeTableQuery)


    }

    override fun onUpgrade(db: SQLiteDatabase, v1: Int, v2: Int) {
        db.execSQL("DROP TABLE IF EXISTS " + Utils.MEDICINE_TABLE_NAME)
        onCreate(db)
    }

    fun addMedicine(medicine: Medicine): Long {
        val values = ContentValues()
        values.put(Utils.MEDICINE_NAME_COL, medicine.name)
        values.put(Utils.MEDICINE_X_TIMES_COL, medicine.xTimes)
        values.put(Utils.MEDICINE_START_DATE_COL, medicine.startDate.time)
        values.put(Utils.MEDICINE_END_DATE_COL, getEndOfDay(medicine.endDate).time)

        val db = this.writableDatabase
        val medicineId = db.insert(Utils.MEDICINE_TABLE_NAME, null, values)
        db.close()

        // Insert medicine times into the MedicineTime table
        for (time in medicine.times) {
            addMedicineTime(medicineId, time)
        }

        return medicineId
    }

    fun updateMedicine(id: Int, medicine: Medicine) {
        val values = ContentValues()
        values.put(Utils.MEDICINE_NAME_COL, medicine.name)
        values.put(Utils.MEDICINE_X_TIMES_COL, medicine.xTimes)
        values.put(Utils.MEDICINE_START_DATE_COL, medicine.startDate.time)
        values.put(Utils.MEDICINE_END_DATE_COL, getEndOfDay(medicine.endDate).time)

        val db = this.writableDatabase
        db.update(Utils.MEDICINE_TABLE_NAME, values, Utils.MEDICINE_ID_COL + "=?", arrayOf(id.toString()))
        db.close()

        // Delete existing medicine times
        deleteMedicineTimes(id)

        // Insert updated medicine times into the MedicineTime table
        for (time in medicine.times) {
            addMedicineTime(id.toLong(), time)
        }
    }

    private fun addMedicineTime(medicineId: Long, timeModel: TimeModel): Long {
        val values = ContentValues()
        values.put(Utils.MEDICINE_ID_COL, medicineId)
        values.put(Utils.MEDICINE_TIME_HOUR_COL, timeModel.hour)
        values.put(Utils.MEDICINE_TIME_MINUTE_COL, timeModel.minute)

        val db = this.writableDatabase
        return db.insert(Utils.MEDICINE_TIME_TABLE_NAME, null, values)
    }

    private fun deleteMedicineTimes(medicineId: Int) {
        val db = this.writableDatabase
        db.delete(Utils.MEDICINE_TIME_TABLE_NAME, "${Utils.MEDICINE_ID_COL}=?", arrayOf(medicineId.toString()))
        db.close()
    }

    fun deleteMedicine(id: Int) {
        val db = this.writableDatabase
        db.delete(Utils.MEDICINE_TABLE_NAME, Utils.MEDICINE_ID_COL + "=?", arrayOf(id.toString()))
        db.close()
    }

    fun readMedicines(): List<Medicine> {
        val medicines = mutableListOf<Medicine>()

        val db = this.readableDatabase
        val cursor = db.rawQuery("SELECT * FROM " + Utils.MEDICINE_TABLE_NAME, null)

        if (cursor.moveToFirst()) {
            do {
                val medicineIdIndex = cursor.getColumnIndex(Utils.MEDICINE_ID_COL)

                if (medicineIdIndex != -1) {
                    val medicineId = cursor.getLong(medicineIdIndex)
                    val medicineNameIndex = cursor.getColumnIndex(Utils.MEDICINE_NAME_COL)
                    val xTimesIndex = cursor.getColumnIndex(Utils.MEDICINE_X_TIMES_COL)
                    val startDateIndex = cursor.getColumnIndex(Utils.MEDICINE_START_DATE_COL)
                    val endDateIndex = cursor.getColumnIndex(Utils.MEDICINE_END_DATE_COL)

                    // Check if the column index is valid before retrieving values
                    val medicineName = if (medicineNameIndex != -1) cursor.getString(medicineNameIndex) else ""
                    val xTimes = if (xTimesIndex != -1) cursor.getInt(xTimesIndex) else -1
                    val startDate = if (startDateIndex != -1) Date(cursor.getLong(startDateIndex)) else Date()
                    val endDate = if (endDateIndex != -1) Date(cursor.getLong(endDateIndex)) else Date()

                    // Retrieve medicine times
                    val times = readMedicineTimes(medicineId)

                    // Construct Medicine object
                    val medicine = Medicine().apply {
                        this.name = medicineName
                        this.xTimes = xTimes
                        this.startDate = startDate
                        this.endDate = endDate
                        this.times = times.toMutableList()
                    }

                    medicines.add(medicine)
                }
            } while (cursor.moveToNext())
        }

        cursor.close()
        db.close()

        return medicines
    }

    fun readMedicinesForDate(date: Date): List<Medicine> {
        val medicines = mutableListOf<Medicine>()

        val db = this.readableDatabase
        val cursor = db.rawQuery(
            "SELECT * FROM ${Utils.MEDICINE_TABLE_NAME} WHERE " +
                    "${Utils.MEDICINE_START_DATE_COL} <= ? AND " +
                    "${Utils.MEDICINE_END_DATE_COL} >= ?",
            arrayOf(date.time.toString(), date.time.toString())
        )

        if (cursor.moveToFirst()) {
            do {
                val medicineIdIndex = cursor.getColumnIndex(Utils.MEDICINE_ID_COL)

                if (medicineIdIndex != -1) {
                    val medicineId = cursor.getLong(medicineIdIndex)
                    val medicineNameIndex = cursor.getColumnIndex(Utils.MEDICINE_NAME_COL)
                    val xTimesIndex = cursor.getColumnIndex(Utils.MEDICINE_X_TIMES_COL)
                    val startDateIndex = cursor.getColumnIndex(Utils.MEDICINE_START_DATE_COL)
                    val endDateIndex = cursor.getColumnIndex(Utils.MEDICINE_END_DATE_COL)

                    // Check if the column index is valid before retrieving values
                    val medicineName = if (medicineNameIndex != -1) cursor.getString(medicineNameIndex) else ""
                    val xTimes = if (xTimesIndex != -1) cursor.getInt(xTimesIndex) else -1
                    val startDate = if (startDateIndex != -1) Date(cursor.getLong(startDateIndex)) else Date()
                    val endDate = if (endDateIndex != -1) Date(cursor.getLong(endDateIndex)) else Date()

                    // Retrieve medicine times
                    val times = readMedicineTimes(medicineId)

                    // Construct Medicine object
                    val medicine = Medicine().apply {
                        this.name = medicineName
                        this.xTimes = xTimes
                        this.startDate = startDate
                        this.endDate = endDate
                        this.times = times.toMutableList()
                    }

                    medicines.add(medicine)
                }
            } while (cursor.moveToNext())
        }

        cursor.close()
        db.close()

        return medicines
    }

    // Helper method to read medicine times
    private fun readMedicineTimes(medicineId: Long): List<TimeModel> {
        val times = mutableListOf<TimeModel>()

        val db = this.readableDatabase
        val cursor = db.rawQuery(
            "SELECT * FROM ${Utils.MEDICINE_TIME_TABLE_NAME} WHERE ${Utils.MEDICINE_ID_COL} = ?",
            arrayOf(medicineId.toString())
        )

        if (cursor.moveToFirst()) {
            do {
                val hourIndex = cursor.getColumnIndex(Utils.MEDICINE_TIME_HOUR_COL)
                val minuteIndex = cursor.getColumnIndex(Utils.MEDICINE_TIME_MINUTE_COL)

                if (hourIndex != -1 && minuteIndex != -1) {
                    val hour = cursor.getInt(hourIndex)
                    val minute = cursor.getInt(minuteIndex)
                    times.add(TimeModel(hour, minute))
                }
            } while (cursor.moveToNext())
        }

        cursor.close()
        db.close()

        return times
    }


    fun addReportData(reportData: ReportData): Long {
        val values = ContentValues()
        values.put(Utils.MEDICINE_NAME_COL, reportData.medicineName)
        values.put(Utils.REPORT_DATA_DATE_TIME_COL, reportData.dateTime.time)
        values.put(Utils.REPORT_DATA_IS_TAKEN_COL, if (reportData.isTaken) 1 else 0)

        val db = this.writableDatabase
        val rowId = db.insert(Utils.REPORT_DATA_TABLE_NAME, null, values)
        db.close()
        return rowId
    }

    fun updateReportData(id: Int, reportData: ReportData) {
        val values = ContentValues()
        values.put(Utils.MEDICINE_NAME_COL, reportData.medicineName)
        values.put(Utils.REPORT_DATA_DATE_TIME_COL, reportData.dateTime.time)
        values.put(Utils.REPORT_DATA_IS_TAKEN_COL, if (reportData.isTaken) 1 else 0)

        val db = this.writableDatabase
        db.update(Utils.REPORT_DATA_TABLE_NAME, values, Utils.REPORT_DATA_ID_COL + "=?", arrayOf(id.toString()))
        db.close()
    }

    fun deleteReportData(id: Int) {
        val db = this.writableDatabase
        db.delete(Utils.REPORT_DATA_TABLE_NAME, Utils.REPORT_DATA_ID_COL + "=?", arrayOf(id.toString()))
        db.close()
    }

    fun readReportData(): Cursor? {
        val db = this.readableDatabase
        return db.rawQuery("SELECT * FROM " + Utils.REPORT_DATA_TABLE_NAME, null)
    }

    private fun getEndOfDay(date: Date): Date {
        val calendar = Calendar.getInstance().apply {
            time = date
            set(Calendar.HOUR_OF_DAY, 23)
            set(Calendar.MINUTE, 59)
            set(Calendar.SECOND, 59)
            set(Calendar.MILLISECOND, 999)
        }
        return calendar.time
    }
}
