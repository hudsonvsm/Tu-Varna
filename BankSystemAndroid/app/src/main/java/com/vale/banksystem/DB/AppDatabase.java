package com.vale.banksystem.DB;

import android.content.Context;

import androidx.room.*;

@Database(entities = {Account.class}, version = 1, exportSchema = false)
public abstract class AppDatabase extends RoomDatabase {
    private static final String DB_NAME = "account_db";
    private static AppDatabase instance;

    public static  synchronized AppDatabase getInstance(Context context) {
        if (instance == null) {
            instance = Room.databaseBuilder(context.getApplicationContext(), AppDatabase.class, DB_NAME)
                    .fallbackToDestructiveMigration()
                    .allowMainThreadQueries()
                    .build();
        }

        return instance;
    }

    public abstract AccessInterface accessInterface();
}
