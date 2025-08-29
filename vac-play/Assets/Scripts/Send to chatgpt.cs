using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace OpenAI
{
    public class SendToChatgpt : MonoBehaviour
    {
        private OpenAIApi openai = new OpenAIApi();
        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "";
        public Button proximo;
        public TextMeshProUGUI textDisplay;

        public void Awake()
        {
            Debug.Log("Sending to ChatGPT...");

            // Configure your prompt based on your variables (cellType, cellSize, etc.)
            string cellType = VariablesController.tipoCelula;
            string cellSize = VariablesController.tamanhoCelula;
            string membrana = VariablesController.tipoMembrana;
            string metabolismo = VariablesController.metabolismo;
            string nutricao = VariablesController.nutricao;
            string reproducao = VariablesController.reproducao;
            string mecanismoDefesa = VariablesController.mecanismoDefesa;
            
            if(cellType == "EUCARIOTO" || cellType == "PROCARIOTO")
            {
                prompt = "Para um " + cellType + " de " + cellSize +
           " com membrana " + membrana + ", metabolismo " + metabolismo +
           ", nutrição " + nutricao + " e reprodução " + reproducao +
           ", quais seriam as condições para sua sobrevivencia em diferentes corpos celestes, ficticionalmente" +
           " (temperatura, pressão e composição atmosférica)?\n" +
           "Estruture a resposta da seguinte forma:\n" +
           "Planeta Gasoso:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Planeta Rochoso:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Planeta Anão:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Lua:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]";

            }
            else
            {
                prompt = "Se a pessoa escolher um " + cellType +
           ", quais seriam as condições para sua sobrevivencia em diferentes corpos celestes, ficticionalmente" +
           " (temperatura, pressão, gravidade e composição atmosférica)?\n" +
           "Estruture a resposta da seguinte forma:\n" +
           "Planeta Gasoso:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Planeta Rochoso:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Planeta Anão:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]\n" +
           "Lua:\n" +
           "- Temperatura: [inserir temperatura ideal]\n" +
           "- Pressão: [inserir pressão ideal]\n" +
           "- Composição Atmosférica: [inserir composição atmosférica]";

            }
            SendReply();
        }

        public async void SendReply()
        {
            Debug.Log("Replying");

            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = prompt
            };

            if (messages.Count == 0)
                messages.Add(newMessage);

            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-4o-mini-2024-07-18",
                Messages = messages
            });

            // Limpar as variáveis para garantir que estejam vazias
            VariablesController.composicaoPlanetaGasoso = "";
            VariablesController.temperaturaPlanetaGasoso = "";
            VariablesController.pressaoPlanetaGasoso = "";
            VariablesController.composicaoPlanetaRochoso = "";
            VariablesController.temperaturaPlanetaRochoso = "";
            VariablesController.pressaoPlanetaRochoso = "";
            VariablesController.composicaoPlanetaAnao = "";
            VariablesController.temperaturaPlanetaAnao = "";
            VariablesController.pressaoPlanetaAnao = "";
            VariablesController.composicaoPlanetaLua = "";
            VariablesController.temperaturaPlanetaLua = "";
            VariablesController.pressaoPlanetaLua = "";

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();
                messages.Add(message);

                Debug.Log("AI Response: " + message.Content);
                VariablesController.retornoGpt = message.Content;

                string respostaCompleta = message.Content;

                // Verifique se o formato compacto está presente
                int indiceInicioGasoso = respostaCompleta.IndexOf("Planeta Gasoso");
                int indiceInicioRochoso = respostaCompleta.IndexOf("Planeta Rochoso");
                int indiceInicioAnao = respostaCompleta.IndexOf("Planeta Anão");
                int indiceInicioLua = respostaCompleta.IndexOf("Lua");

                if (indiceInicioGasoso >= 0)
                {
                    // Tipo de resposta: Formato compacto para Planeta Gasoso
                    // Procure e extraia informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    int indiceInicioTemperatura = respostaCompleta.IndexOf("Temperatura:", indiceInicioGasoso);
                    int indiceInicioPressao = respostaCompleta.IndexOf("Pressão:", indiceInicioGasoso);
                    int indiceInicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", indiceInicioGasoso);

                    // Extrair informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    string temperaturaHabitavelGasoso = respostaCompleta.Substring(indiceInicioTemperatura + 12, indiceInicioPressao - indiceInicioTemperatura - 12).Trim();
                    string pressaoGasoso = respostaCompleta.Substring(indiceInicioPressao + 9, indiceInicioComposicao - indiceInicioPressao - 9).Trim();
                  //  int inicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", inicioGasoso);

                    if (indiceInicioComposicao >= 0)
                    {
                        // Encontrou a seção de composição atmosférica para o Planeta Gasoso
                        int fimComposicao = respostaCompleta.IndexOf("Planeta Rochoso", indiceInicioComposicao);

                        if (fimComposicao < 0)
                        {
                            // Se não encontrou "Planeta Rochoso," então estamos no último tipo de planeta (Lua)
                            fimComposicao = respostaCompleta.Length;
                        }

                        string composicaoGasoso = respostaCompleta.Substring(indiceInicioComposicao + 22, fimComposicao - indiceInicioComposicao - 22).Trim();
                        VariablesController.composicaoPlanetaGasoso = composicaoGasoso;
                    }
                        // Salve as informações em variáveis
                     //   VariablesController.composicaoPlanetaGasoso = composicaoGasoso;
                    VariablesController.temperaturaPlanetaGasoso = temperaturaHabitavelGasoso;
                    VariablesController.pressaoPlanetaGasoso = pressaoGasoso;
                }

                // Repita o mesmo processo para os outros tipos de planetas (Rochoso, Anão e Lua)

                if (indiceInicioRochoso >= 0)
                {
                    // Tipo de resposta: Formato compacto para Planeta Gasoso
                    // Procure e extraia informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    int indiceInicioTemperatura = respostaCompleta.IndexOf("Temperatura:", indiceInicioRochoso);
                    int indiceInicioPressao = respostaCompleta.IndexOf("Pressão:", indiceInicioRochoso);
                    int indiceInicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", indiceInicioRochoso);

                    // Extrair informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    string temperaturaHabitavelRochoso = respostaCompleta.Substring(indiceInicioTemperatura + 12, indiceInicioPressao - indiceInicioTemperatura - 12).Trim();
                    string pressaoRochoso = respostaCompleta.Substring(indiceInicioPressao + 9, indiceInicioComposicao - indiceInicioPressao - 9).Trim();
                 //   int inicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", indiceInicioRochoso);

                    if (indiceInicioComposicao >= 0)
                    {
                        // Encontrou a seção de composição atmosférica para o Planeta Rochoso
                        int fimComposicao = respostaCompleta.IndexOf("Planeta Anão", indiceInicioComposicao);

                        if (fimComposicao < 0)
                        {
                            // Se não encontrou "Planeta Anão," então estamos no último tipo de planeta (Lua)
                            fimComposicao = respostaCompleta.Length;
                        }

                        string composicaoRochoso = respostaCompleta.Substring(indiceInicioComposicao + 22, fimComposicao - indiceInicioComposicao - 22).Trim();
                        VariablesController.composicaoPlanetaRochoso = composicaoRochoso;
                    }
                    else
                    {
                        VariablesController.composicaoPlanetaRochoso = "Nitrogênio (N2): 68%\r\nOxigênio (O2): 20%\r\nDióxido de Carbono (CO2): 7%\r\nArgônio (Ar): 3%\r\nVapor d'água (H2O): 1%\r\nTraços de outros gases, incluindo metano (CH4) e amônia (NH3): 1%";
                    }
                    // Salve as informações em variáveis
                    //  VariablesController.composicaoPlanetaRochoso = composicaoRochoso;
                    VariablesController.temperaturaPlanetaRochoso = temperaturaHabitavelRochoso;
                    VariablesController.pressaoPlanetaRochoso = pressaoRochoso;
                }

                if (indiceInicioAnao >= 0)
                {
                    // Tipo de resposta: Formato compacto para Planeta Gasoso
                    // Procure e extraia informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    int indiceInicioTemperatura = respostaCompleta.IndexOf("Temperatura:", indiceInicioAnao);
                    int indiceInicioPressao = respostaCompleta.IndexOf("Pressão:", indiceInicioAnao);
                    int indiceInicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", indiceInicioAnao);

                    // Extrair informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    string temperaturaHabitavelAnao = respostaCompleta.Substring(indiceInicioTemperatura + 12, indiceInicioPressao - indiceInicioTemperatura - 12).Trim();
                    string pressaoAnao = respostaCompleta.Substring(indiceInicioPressao + 9, indiceInicioComposicao - indiceInicioPressao - 9).Trim();
                    string composicaoAnao = respostaCompleta.Substring(indiceInicioComposicao + 22).Trim();

                    // Salve as informações em variáveis
                    VariablesController.composicaoPlanetaAnao = composicaoAnao;
                    VariablesController.temperaturaPlanetaAnao = temperaturaHabitavelAnao;
                    VariablesController.pressaoPlanetaAnao = pressaoAnao;
                }

                if (indiceInicioLua >= 0)
                {
                    // Tipo de resposta: Formato compacto para Planeta Gasoso
                    // Procure e extraia informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    int indiceInicioTemperatura = respostaCompleta.IndexOf("Temperatura:", indiceInicioLua);
                    int indiceInicioPressao = respostaCompleta.IndexOf("Pressão:", indiceInicioLua);
                    int indiceInicioComposicao = respostaCompleta.IndexOf("Composição Atmosférica:", indiceInicioLua);

                    // Extrair informações de temperatura, pressão e composição atmosférica do Planeta Gasoso
                    string temperaturaHabitavelLua = respostaCompleta.Substring(indiceInicioTemperatura + 12, indiceInicioPressao - indiceInicioTemperatura - 12).Trim();
                    string pressaoLua = respostaCompleta.Substring(indiceInicioPressao + 9, indiceInicioComposicao - indiceInicioPressao - 9).Trim();
                    string composicaoLua = respostaCompleta.Substring(indiceInicioComposicao + 22).Trim();

                    // Salve as informações em variáveis
                    VariablesController.composicaoPlanetaLua = composicaoLua;
                    VariablesController.temperaturaPlanetaLua = temperaturaHabitavelLua;
                    VariablesController.pressaoPlanetaLua = pressaoLua;
                }


                // dps que está tudo certo, o botao pode aparecer
                proximo.GetComponentInChildren<Image>().enabled = true;
                textDisplay.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }
        }
    }
}
