package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

public class MainActivity extends AppCompatActivity {
    String ad;
    String soyad;
    String sehir;
    String meslek;

    int kayitSinir = 5;

    TextView kayitHakki;

    EditText adInput;
    EditText soyadInput;
    EditText sehirInput;
    EditText meslekInput;

    Button kayit;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        kayitHakki = (TextView) findViewById(R.id.kayitHakki);

        adInput = (EditText) findViewById(R.id.edit1);
        soyadInput = (EditText) findViewById(R.id.edit2);
        sehirInput = (EditText) findViewById(R.id.edit3);
        meslekInput = (EditText) findViewById(R.id.edit4);

        kayit = (Button) findViewById(R.id.btn1);

        kayit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(TextUtils.isEmpty(adInput.getText().toString()) ||
                        TextUtils.isEmpty(soyadInput.getText().toString()) ||
                        TextUtils.isEmpty(sehirInput.getText().toString()) ||
                        TextUtils.isEmpty(meslekInput.getText().toString())){
                    showToast("Tum alanlari doldurmalisiniz.");
                }
                else{
                    showToast(sehirInput.getText() + " Dogumlu " + meslekInput.getText()
                    + " Meslegine sahip " + adInput.getText() + " " + soyadInput.getText() +
                            "kaydin basarili bir sekilde alindi.");
                }
                if(kayitSinir != 0){
                    kayitSinir--;
                    kayitHakki.setText("Kayit Hakki: " + kayitSinir);
                }
                if(kayitSinir == 0){
                    kayit.setClickable(false);
                    showToast("Kayit hakkiniz bitti.");
                }



            }
        });


    }
    private void showToast(String text){
        Toast.makeText(MainActivity.this, text, Toast.LENGTH_SHORT).show();
    }
}