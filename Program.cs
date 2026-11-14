using System;
using System.Collections.Generic;

public class Program
{
    static List<Consulta> Consultas = new List<Consulta>();
    static List<Animal> Animais = new List<Animal>();
    static List<Veterinario> Veterinarios = new List<Veterinario>();
    public static void Main(string[] args)
    {
        Console.WriteLine("***************************************");
        Console.WriteLine("*****    Sistema de Agendamento   *****");
        Console.WriteLine("***** Clínica Veterinária VidaPet *****");
        Console.WriteLine("***************************************");
        Console.WriteLine();
        Console.WriteLine("         ** Primeiro Acesso **");
        Console.WriteLine();
        Console.WriteLine("Cadastro do Recepcionista:");
        Console.WriteLine();
        Console.Write("    Login: "); 
        string loginRecepcionista = Console.ReadLine()??"";
        
        //Console.Write(  "    Senha: "); 
        //string senhaRecepcionista = Console.ReadLine()??"";

        Console.WriteLine();
        Console.WriteLine("Cadastro feito com sucesso!:");
        Console.WriteLine();
        Console.WriteLine("***************************************");

        byte opcao;
        do 
        {
            Console.WriteLine();
            Console.WriteLine("Qual tipo de usuário você é?");
            Console.WriteLine();
            Console.WriteLine("    1 - Recepcionista"); // so recebe informações e acessa, so agenda e cancela consultas e cadastra animais e veterinários
            Console.WriteLine("    2 - Veterinário"); // so realiza consulta, registra observações e acessa os agendamentos                                       
            Console.WriteLine("    0 - Encerrar o programa");
            Console.WriteLine();

            Console.Write(  "Opção escolhida: "); 
            bool success = byte.TryParse(Console.ReadLine(),out opcao);

            switch (opcao) 
            {

            // Menu do recepcionista

                case 1:
                    Console.WriteLine("***************************************");
                    Console.WriteLine("*****    Sistema de Agendamento   *****");
                    Console.WriteLine("***** Clínica Veterinária VidaPet *****");
                    Console.WriteLine("***************************************");
                    Console.WriteLine();
                    Console.WriteLine("1 - Cadastrar animal");
                    Console.WriteLine("2 - Cadastrar veterinário");
                    Console.WriteLine("3 - Observações");
                    Console.WriteLine("4 - Agendar consulta");
                    Console.WriteLine("5 - Cancelar consulta");
                    Console.WriteLine("0 - Voltar ao menu principal");
                    //guarda a opção do recepcionista
                    byte opcaoRecepcionista;
                        
                    // recebe a opção digitada
                    Console.Write(  "Opção escolhida: "); 
                    bool entradaValida = byte.TryParse(Console.ReadLine(),out opcaoRecepcionista);
                        
                    switch(opcaoRecepcionista)
                    {
                        case 1:
                            // Aqui vai armazenar tudo sobre o animal e vai entrar na lista
                            
                            Random gerador = new Random();
                            int idAnimal;
                            do
                            {
                                idAnimal = gerador.Next(100000000, 1000000000); // é assim que geramos números aleatórios
                            }while (Animais.Exists(a => a.Id== idAnimal));
                            Animal animal = new Animal(idAnimal);
                            
                            Console.WriteLine("Qual o telefone do tutor?");
                            animal.TelefoneTutor = Console.ReadLine()??"";
                            
                            Console.WriteLine("Qual o nome do tutor?");
                            animal.NomeTutor = Console.ReadLine()??"";
                            
                            Console.WriteLine("Qual o nome do animal?");
                            animal.Nome = Console.ReadLine()??"";
                            
                            Console.WriteLine("Qual a espécie do animal?");
                            animal.Especie = Console.ReadLine()??"";
                            
                            int idadeAnimal;
                            bool idadeValida;
                            
                            do
                            {
                                Console.WriteLine("Qual a idade do animal?");

                                idadeValida = int.TryParse(Console.ReadLine(), out idadeAnimal );

                                if (!idadeValida || idadeAnimal < 0 || idadeAnimal > 50 )
                                {
                                    Console.WriteLine("Erro: informe uma idade válida entre 0 e 50 anos");
                                }
                            }while (!idadeValida || idadeAnimal < 0 || idadeAnimal > 50);

                            animal.Idade= idadeAnimal;

                            //Verificação de cadastro do animal

                            bool animalExistente = Animais.Exists(a =>
                            a.Nome == animal.Nome &&
                            a.Especie == animal.Especie &&
                            a.Idade == animal.Idade &&
                            a.NomeTutor == animal.NomeTutor &&
                            a.TelefoneTutor == animal.TelefoneTutor);

                            if(animalExistente)
                            {
                                Console.WriteLine("Erro: este animal já foi cadastrado");
                            }
                            else{
                            //adiciona os dados a lista
                                Animais.Add(animal);

                                Console.WriteLine("Animal cadastrado !");
                                Console.WriteLine($"ID do animal: {animal.Id}");
                                Console.WriteLine($"Total de animais cadastrados: {Animais.Count}");
                            }                       
                        // Agendamento será feito no case 4.

                            break;

                        case 2:
                        // aqui armazena tudo sobre o veterinario
                            Veterinario veterinario = new Veterinario();

                            Console.WriteLine("Nome do veterinário");
                            veterinario.Nome = Console.ReadLine()??"";
                            
                            Console.WriteLine("CRMV");
                            veterinario.CRMV = (Console.ReadLine()??"").Trim();
                            
                            // Verificação de cadastro
                            if (string.IsNullOrWhiteSpace(veterinario.CRMV))
                            {
                                Console.WriteLine("Erro: o CRMV não pode estar vazio");
                            }
                            else if(Veterinarios.Exists(
                                vet => vet.CRMV.Equals( veterinario.CRMV, StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("Erro: CRMV já cadastrado");
                            }
                            else
                            {
                                Veterinarios.Add(veterinario);
                                //adicona veterinarios a lista
                                Console.WriteLine("Veterinario cadastrado");
                            
                                Console.WriteLine($"Total de veterinários cadastrados: {Veterinarios.Count}");
                            }
                            break;
                            
                        case 3:
                            Consulta consulta = new Consulta(); // acessa informações sobre a consulta 
                            Console.WriteLine("Observações");
                            break;

                        case 4:
                            Consulta consulta1 = new Consulta(); // agenda a consulta
                            Consultas.Add(consulta1);
                            Console.WriteLine("Agendar consulta");
                            break;

                        case 5:
                        //cancela a consulta
                            for (int i = 0; i < Consultas.Count; i++)
                            {
                                if (Consultas[i].Situacao == "agendada")
                                {
                                    Console.WriteLine($"Consulta {i + 1}:");
                                    Console.WriteLine($"Data e Hora: {Consultas[i].DataHora}");
                                    Console.WriteLine();
                                } 
                            }
                            
                            if (Consultas.Count > 0)
                            {
                                Console.WriteLine("Deseja cancelar qual consulta? (digite o número da consulta)");
                                string resposta = Console.ReadLine()??"";
                                int.TryParse(resposta, out int numeroConsulta);
                                Consultas [numeroConsulta - 1].Situacao = "cancelada";
                            }
                            break;
                        case 0:
                            Console.WriteLine("Voltando ao menu principal");
                            break;
                    }

                    break;

                // Menu do veterinário
                case 2:
                    Console.WriteLine("***************************************");
                    Console.WriteLine("*****    Sistema de Agendamento   *****");
                    Console.WriteLine("***** Clínica Veterinária VidaPet *****");
                    Console.WriteLine("***************************************");
                    Console.WriteLine();
                    Console.WriteLine("1 - Consultar agenda");
                    Console.WriteLine("2 - Realizar consulta");
                    Console.WriteLine("3 - Registrar observações");
                    Console.WriteLine("0 - Voltar ao menu principal");
                    //guarda a opção do veterinário
                    byte opcaoVeterinario;

                    // recebe a opção digitada
                    Console.Write(  "Opção escolhida: "); 
                    bool entradaValidaVet = byte.TryParse(Console.ReadLine(),out opcaoVeterinario);
                            
                    switch(opcaoVeterinario)
                    {
                        case 1:
                            Consulta consulta2 = new Consulta(); // acessa informações 
                            Console.WriteLine("Consultar agenda");
                            break;

                        case 2:
                            Consulta consulta3 = new Consulta(); // realiza consulta
                            Console.WriteLine("Realizar consulta");
                            break;

                        case 3:
                            Consulta consulta4 = new Consulta(); // registrar observações
                            Console.WriteLine("Registrar observações");
                            break;

                        case 0:
                            Console.WriteLine("Voltando ao menu principal");
                            break;
                    }

                    break;
                
                // Encerramento do programa
                case 0:
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }// fecha o Main 
}// fecha o Program


/* Menu de opções para o recepcionista
Console.WriteLine("1 - Cadastrar animal:");
Console.WriteLine("2 - Cadastrar veterinário:");
Console.WriteLine("3 - Observações:");
Console.WriteLine("4 - Cancelar consulta:");
Console.WriteLine("0 - Sair:");
//receber informações do animal e do veterinário e salvar na variavel "Animal", "Veterinario" e "Consulta"

Console.WriteLine("1 - Telefone do tutor:");
Console.WriteLine("2 - Nome do tutor:");
Console.WriteLine("3 - Nome do animal:");
Console.WriteLine("4 - Especie do animal:");
Console.WriteLine("5 - Idade do animal:");
Console.WriteLine("6 - Agendar consulta:");
Console.WriteLine("7 - Situação (agendada, realizada ou cancelada):");
Console.WriteLine("0 - Sair:");
//salvar informações do animal na variavel "Animal"


Console.WriteLine("1 - Nome do veterinário:");
Console.WriteLine("2 - CRMV:");
Console.WriteLine("0 - Sair:");
//salvar informações do veterinário na variavel "Veterinario"

// Menu de opções para o veterinário
Console.WriteLine("1 - Consultar agenda:");
Console.WriteLine("2 - Realizar consulta:");
Console.WriteLine("3 - Registrar observações:");
Console.WriteLine("0 - Sair:");
//salvar informações da consulta na variavel "Consulta"

//mensagem de erro
Console.WriteLine("Opção inválida. Por favor, registre somente cães ou gatos:");
Console.WriteLine("Opção inválida. Por favor, agende a consulta somente nos horários disponíveis de 8h às 18h:");
Console.WriteLine("Opção inválida. Por favor, tente somente dias posteriores à data atual:");
Console.WriteLine("Opção inválida. Por favor, tente registrar em outro horário, este está ocupado:");
Console.WriteLine("Opção inválida. Por favor, so cancele consultas já agendadas:");

//mensagem de aviso
Console.WriteLine("Consulta não encontrada:");
Console.WriteLine("Consulta agendada com sucesso:");
Console.WriteLine("Consulta realizada com sucesso:");
Console.WriteLine("Consulta cancelada com sucesso:");
Console.WriteLine("Animal cadastrado com sucesso:");
Console.WriteLine("Veterinário cadastrado com sucesso:");
Console.WriteLine("Agenda: var=agenda");     
Console.WriteLine("Observações enviadas com sucesso:");
Console.WriteLine("Observações do veterinário: var=observacoes"); 
Console.WriteLine("Consulta já realizada, não é possível cancelar:");
Console.WriteLine("Consulta já cancelada, não é possível cancelar novamente:");
Console.WriteLine("Consulta já realizada, não é possível reagendar:"); */