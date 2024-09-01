package com.hackathon.controller;

import org.springframework.web.bind.annotation.PostMapping;
import com.hackathon.dto.peticiones.PeticionMinar;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import lombok.AllArgsConstructor;

import com.hackathon.services.ServicioMinar;

@RestController
@AllArgsConstructor
@RequestMapping("/api/jugadas")
public class JugadasController {
  private final ServicioMinar servMinar;

  @PostMapping("/minar")
  public void mover(PeticionMinar movimiento) {
    servMinar.servir(movimiento);
  }
}