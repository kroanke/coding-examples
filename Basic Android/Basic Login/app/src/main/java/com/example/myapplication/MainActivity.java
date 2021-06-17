package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    String name;
    int age;
    EditText nameInput;
    EditText ageInput;

    Button submit;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        nameInput = (EditText) findViewById(R.id.isimText);
        ageInput = (EditText) findViewById(R.id.yasText);

        submit = (Button) findViewById(R.id.button);
        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(MainActivity.this, MainActivity2.class);

                name = nameInput.getText().toString();
                age = Integer.valueOf(ageInput.getText().toString());

                i.putExtra("Isim", name);
                i.putExtra("Yas", age);


//                showToast(name);
//                showToast(String.valueOf(age));

                startActivity(i);
                finish();

            }
        });

    }

}