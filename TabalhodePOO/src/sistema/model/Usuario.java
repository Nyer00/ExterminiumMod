package sistema.model;
import java.util.UUID;

public class Usuario {
	private String email, senha, cep, cpf, dataNascimento, nome;
	private int telefone;
	private UUID id;
	
	public Usuario(String email, String senha, String cep, String cpf, String dataNascimento, String nome, int telefone) {
		this.email = email;
		this.senha = senha;
		this.cep = cep;
		this.cpf = cpf;
		this.dataNascimento = dataNascimento;
		this.nome = nome;
		this.telefone = telefone;
		this.id = UUID.randomUUID();
	}
	
	public Usuario() {
		
	}

	public String getEmail() {
		return email;
	}
	
	public void setEmail(String email) {
		this.email = email;
	}
	
	public String getSenha() {
		return senha;
	}
	
	public void setSenha(String senha) {
		this.senha = senha;
	}
	
	public String getCep() {
		return cep;
	}
	
	public void setCep(String cep) {
		this.cep = cep;
	}
	
	public String getCpf() {
		return cpf;
	}
	
	public void setCpf(String cpf) {
		this.cpf = cpf;
	}
	
	public String getDataNascimento() {
		return dataNascimento;
	}
	
	public void setDataNascimento(String dataNascimento) {
		this.dataNascimento = dataNascimento;
	}
	
	public String getNome() {
		return nome;
	}
	
	public void setNome(String nome) {
		this.nome = nome;
	}
	
	public int getTelefone() {
		return telefone;
	}
	
	public void setTelefone(int telefone) {
		this.telefone = telefone;
	}

	public UUID getId() {
		return id;
	}	
}
