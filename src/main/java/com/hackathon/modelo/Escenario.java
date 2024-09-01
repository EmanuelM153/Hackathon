package com.hackathon.modelo;

import java.util.ArrayList;

public abstract class Escenario {
  private final ArrayList<Usuario> usuarios;

  public Escenario() {
    this.usuarios = new ArrayList<>();
  }
}
