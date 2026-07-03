using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;

namespace Assets.Scripts.Tracker
{
    public class SendTrackerLocal : MonoBehaviour
    {
        public string objectId;
        public string objectName;
        public CustomHighLevelTracker.TrackedGameObject objectType = CustomHighLevelTracker.TrackedGameObject.GameObject;

        string GetDescription(string local)
        {
            if (local == "Planeta Gasoso")
            {
                return $"Escolheu Planeta Gasoso: Composição: {VariablesController.composicaoPlanetaGasoso}, Temperatura: {VariablesController.temperaturaPlanetaGasoso}, Pressão: {VariablesController.pressaoPlanetaGasoso}";
            }
            else if (local == "Planeta Rochoso")
            {
                return $"Escolheu Planeta Rochoso: Composição: {VariablesController.composicaoPlanetaRochoso}, Temperatura: {VariablesController.temperaturaPlanetaRochoso}, Pressão: {VariablesController.pressaoPlanetaRochoso}";
            }
            else if (local == "Planeta Anão")
            {
                return $"Escolheu Planeta Anão: Composição: {VariablesController.composicaoPlanetaAnao}, Temperatura: {VariablesController.temperaturaPlanetaAnao}, Pressão: {VariablesController.pressaoPlanetaAnao}";
            }
            else if (local == "Lua")
            {
                return $"Escolheu Lua: Composição: {VariablesController.composicaoPlanetaLua}, Temperatura: {VariablesController.temperaturaPlanetaLua}, Pressão: {VariablesController.pressaoPlanetaLua}";
            }

            return "Informações não disponíveis para este local.";
        }

        public void Interacted(string local)
        {
            CustomHighLevelTracker.Instance.ChoosedWithDescription(
                objectId,
                objectType,
                objectName,
                GetDescription(local)
            );
        }
    }
}
