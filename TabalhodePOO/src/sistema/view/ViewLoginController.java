package sistema.view;

import sistema.model.*;
import java.util.Observer;
import java.UUID.*;

public class ViewLoginController {

    private ViewLogin view;
    private Model model;

    public void initViewLoginController(Model model, ViewLogin view){
        this.model = model;
        this.view = view;
    }

    public void interacao(int caso){
        switch (caso){
            case 1:
                boolean Flag = model.verificarUsuario(view.getLogin(), view.getSenha());
                //Necessario fazer o Metodo verificarUsuario --> Danilo
                //Metodo verificarLogin recebe login e senha e retorna True (to me baseando no codigo do Samurai)
                //Caso nao haja um Usuario com esse login e senha retorne False.
                if(Flag){
                    view.mensagem("Usuario verificado");
                    UUID id = model.getID(view.getLogin());
                    view.goMenu(id);
                    //Necessario fazer os metodo mensagem() e irMenu() --> Rian
                    //Metodo mensagem() digita algo na tela, e o metodo irMenu() instancia um objeto ViewMenu e chama initViewMenu().
                }else{
                    view.mensagem("Login ou Senha invalido");
                }
                break;
            case 2:
                view.goCadastro();
                //Necessario Fazer o metodo cadastrarUsuario() --> Rian
                //O metodo cadastrarUsuario instancia um objeto ViewCadastro e chama initViewCadastro()
                break;
            case 3:
                view.goRedefinirSenha();
                //Necessario Fazer o metodo redefinirSenha() --> Rian
                //O metodo cadastrarUsuario instancia um objeto ViewNovaSenha e chama initViewNovaSenha()
                break;
        }
    }
}
