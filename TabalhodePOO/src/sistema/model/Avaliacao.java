package sistema.model;

import java.util.UUID;

public class Avaliacao {
	private int nota;
	private Usuario participante;
	private String coment;
	private Evento event;
	private UUID id;
	
	public Avaliacao(int nota, Usuario participante, String coment, Evento event) {
		this.nota = nota;
		this.participante = participante;
		this.coment = coment;
		this.event = event;
		this.id = UUID.randomUUID();
	}

	public int getNota() {
		return nota;
	}

	public void setNota(int nota) {
		this.nota = nota;
	}

	public Usuario getParticipante() {
		return participante;
	}

	public String getComent() {
		return coment;
	}

	public void setComent(String coment) {
		this.coment = coment;
	}

	public Evento getEvent() {
		return event;
	}

	public UUID getId() {
		return id;
	}
	
}
