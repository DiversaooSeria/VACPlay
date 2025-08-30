using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace OpenAI
{
    public class AskChatgotEvolution : MonoBehaviour
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
            string tipoPlaneta = VariablesController.tipoPlaneta;
            string localExperimento = VariablesController.localExperimento;
            string tipoEvento = VariablesController.tipoEvento;

            if (cellType == "EUCARIOTO" || cellType == "PROCARIOTO")
            {

                if(tipoEvento != null)
                {
                    prompt = "A pessoa escolheu evoluir um " + cellType + " de " + cellSize +
                        " que tenha a membrana mais " + membrana + ", um metabolismo " + metabolismo +
                        ", com nutrição " + nutricao +
                        " e reprodução " + reproducao + ", com mecanismo de defesa " + mecanismoDefesa +
                        ", no corpo celeste " + tipoPlaneta + " em " + localExperimento + " tendo um evento aleatorio adicional de "+ tipoEvento+
                        ". Pensando mais de forma fictícia e simulacional, como seria uma possivel evolução deles? Escreva de forma resumida e objetiva, tópicos de no maximo uma linha";

                }
                else
                {
                    prompt = "A pessoa escolheu evoluir um " + cellType + " de " + cellSize +
                        " que tenha a membrana mais " + membrana + ", um metabolismo " + metabolismo +
                        ", com nutrição " + nutricao +
                        " e reprodução " + reproducao + ", com mecanismo de defesa " + mecanismoDefesa +
                        ", no corpo celeste " + tipoPlaneta + " em " + localExperimento +
                        "Pensando mais de forma fictícia e simulacional, como seria uma possivel evolução deles? Escreva de forma resumida e objetiva , tópicos de no maximo uma linha";

                }
            }
            else
            {
                if (tipoEvento != null)
                {
                    prompt = "A pessoa escolheu evoluir um " + cellType +
                   ", no corpo celeste " + tipoPlaneta + " em " + localExperimento + " tendo um evento aleatorio adicional de " + tipoEvento +
                   ". Pensando mais de forma fictícia e simulacional, como seria uma possivel evolução deles?";
                }
                else
                {
                    prompt = "o Jogador escolheu evoluir o organismo " + cellType +
                    ", no corpo celeste " + tipoPlaneta +" em " + localExperimento +
                    ". Pensando mais de forma fictícia e simulacional, como seria uma possivel evolução do organismo selecionado nestas condições??";
                }
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
           /* var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });*/

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();
                messages.Add(message);

                Debug.Log("AI Response: " + message.Content);
                VariablesController.retornoGptEvolucao = message.Content;
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
