package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity2 extends AppCompatActivity {

    TextView isim;
    TextView yas;


    String name;
    int age;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        isim = findViewById(R.id.isimTextView);
        yas = findViewById(R.id.yasTextView);

        name = getIntent().getExtras().getString("Isim");
        isim.setText("Isim: " + name);

        age = getIntent().getExtras().getInt("Yas");
        yas.setText("Yas: " + age);

        if(age < 7){
            showToast("Bu uygulama 7 yasindan buyukler icindir");
            final Handler handler = new Handler(Looper.getMainLooper());
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    finish();
                }
            }, 100);
        }

    }

    private void showToast(String text){
        Toast.makeText(MainActivity2.this, text, Toast.LENGTH_SHORT).show();
    }
}