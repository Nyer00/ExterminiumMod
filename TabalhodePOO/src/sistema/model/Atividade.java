package sistema.model;

import java.util.HashMap;
import java.util.UUID;
//Alguns atributos nao tem setters pois nao podem ser mudados.

public class Atividade {
	private String nome;
	private String data, horaInicio, horaFim;
	private HashMap<Integer, Object> listPart;
	private Usuario palestrante;
	private Evento evento;
	private UUID id;

	public Atividade(String nome, String data, String horaInicio, String horaFim, Evento evento) {
		this.id = UUID.randomUUID();
		this.nome = nome;
		this.data = data;
		this.horaInicio = horaInicio;
		this.horaFim = horaFim;
		this.evento = evento;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public String getData() {
		return data;
	}

	public void setData(String data) {
		this.data = data;
	}

	public String getHoraInicio() {
		return horaInicio;
	}

	public void setHoraInicio(String horaInicio) {
		this.horaInicio = horaInicio;
	}

	public String getHoraFim() {
		return horaFim;
	}

	public void setHoraFim(String horaFim) {
		this.horaFim = horaFim;
	}

	public Usuario getPalestrante() {
		return palestrante;
	}

	public void setPalestrante(Usuario palestrante) {
		this.palestrante = palestrante;
	}

	public Evento getEvento() {
		return evento;
	}

	public void setEvento(Evento evento) {
		this.evento = evento;
	}

	public UUID getId() {
		return id;
	}

}
