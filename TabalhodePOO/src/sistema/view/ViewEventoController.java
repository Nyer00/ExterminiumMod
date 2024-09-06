package sistema.view;

import sistema.model.*;

public class ViewEventoController {
	private ViewEvento view;
	private Model model;

	public void initViewEventoController(Model model, ViewEvento view) {
		this.view = view;
		this.model = model;
	}

	public void interacao(int caso) {
		switch (caso) {
		case 1:
			if (model.getUsuario(view.getEmail()) == model.getOrganizador(view.getEmail(), view.getEvento())) {
				view.goCriarAtividade(view.getEmail());
			} else {
				view.mensagem("Apenas Organizadores podem criar Atividades");
			}
		case 2:
			if (model.getUsuario(view.getEmail()) == model.getOrganizador(view.getEmail(), view.getEvento())) {
				view.goEditarEvento(View.getEmail);
			} else {
				view.mensagem("Apenas Organizadores podem editar o evento");
			}
		case 3:
			//Classe imcompleta
		}
	}
}
