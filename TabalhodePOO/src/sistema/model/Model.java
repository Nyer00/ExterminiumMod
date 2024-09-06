package sistema.model;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;
import java.util.InputMismatchException;

public class Model {
	private Map<UUID, Usuario> usuarios = new HashMap<>();
	private Map<UUID , Evento> eventos = new HashMap<>();
	private Map<UUID, Atividade> atividades = new HashMap<>();
	
	private boolean verificarCPF(String cpf) {
		//Fazer essa parada funcionar
		return true;
	}	
	
	public boolean criarUsuario(String email, String senha, String cep, String cpf, String dataNascimento, String nome, int telefone) {
		if (verificarCPF(cpf)) {
			Usuario user = new Usuario( email,  senha,  cep,  cpf,  dataNascimento,  nome, telefone);
			usuarios.put(user.getId() , user);
			return true;
		}
		return false;
	}
	
	public boolean criarEvento(String nome, String local, String dataInicio, String dataFim,  Usuario organizador) {
		Evento evento = new Evento( nome,  local,  dataInicio,  dataFim,  organizador);
		eventos.put(evento.getId(), evento);
			return true;
	}
	
	public boolean criarAtividade(String nome, String data, String horaInicio, String horaFim, Evento evento) {
		Atividade atividade = new Atividade( nome,  data,  horaInicio,  horaFim,  evento);
		atividades.put(atividade.getId(), atividade);
			return true;
	}
	
   public boolean verificarLogin(String Nome, String senha) {
	   // danilao dev vai "desenvolver" depois
	return false;   
   }
   
	     
   }
   //public boolean trocarSenha(String cpf, UUID id ) {
	 //  UUID Buscador = id;
	  
	    
	   //return true;
	   
   //}


