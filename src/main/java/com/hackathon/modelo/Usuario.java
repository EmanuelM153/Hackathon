package com.hackathon.modelo;

import org.apache.commons.codec.digest.DigestUtils;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Usuario {
  private final String pubKey;
  private final String id;
  private int xPos;
  private int yPos;

  public Usuario(String pubkey) {
    this.pubKey = pubkey;
    this.id = DigestUtils.sha256Hex(pubkey);
  }
}