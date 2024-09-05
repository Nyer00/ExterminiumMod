package sistema.view;

import sistema.model.*;
import java.util.UUID;

public class ViewCadastroController {
    private ViewCadastro view;
    private Model model;

    public void initViewCadastroController(Model model, ViewCadastro view) {
        this.view = view;
        this.model = model;
    }

    public void interacao(int caso){
        switch(caso){
            //necessario criar uma verificacao -->Rian ou Arthur ou Bernardo
            case 1:
                if(model.criarUsuario(view.getEmail(), view.getSenha(), view.getCep(), view.getCpf(),view.getDataNascimento(), view.getNome(), view.getTelefone())){
                    view.mensagem("cadastro feito");
                    view.goLogin();
                }else{
                    view.mensagem("credenciais invalidas");
                    view.cadastrar();
                }
                //model.criarUsuario(view.getEmail(), view.getSenha(), view.getCep(), view.getCpf(),
                        //view.getDataNascimento(), view.getNome(), view.getTelefone());

                //Necessario fazer o metodo irLogin()
                // IrLogin é o metodo que instancia o objeto ViewLogin e inicia o metodo initViewLogin.
            case 2:
                view.goLogin();
        }
    }

}
