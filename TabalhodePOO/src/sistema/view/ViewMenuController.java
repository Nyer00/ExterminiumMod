package sistema.view;

import sistema.model.*;

public class ViewMenuController {
	private ViewMenu view;
	private Model model;
	
	public void initViewMenuController(Model model, ViewMenu view) {
		this.model = model;
		this.view = view;
	}
	
	public void interacao(int caso) {
		switch (caso) {
			case 1:
				view.goCriarEvento(view.getEmail());
			case 2:
				view.goPerfil(view.getEmail());
			case 3:
				//Discutivel, nao sei como funcionaria o metodo pesquisar.
			case 4:
				model.entrarEvento(view.getEvento(), view.getEmail());
				view.goEvento(view.getEmail());
		}
	}
}
