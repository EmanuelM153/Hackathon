package com.hackathon.services;

import org.springframework.stereotype.Service;

import com.hackathon.dto.peticiones.PeticionMinar;

@Service
public class ServicioMinar {
  private final String pubKey = "";
  private final String privateKey = "";

  //private final Credentials credenciales;

  public ServicioMinar() {
    //credenciales = Credentials.create(privateKey, pubKey);
  }

  public void servir(PeticionMinar peticion) {
    System.out.println(peticion);
  }
}
