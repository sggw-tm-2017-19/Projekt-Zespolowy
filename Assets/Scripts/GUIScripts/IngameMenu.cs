using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml.Serialization;

public class IngameMenu : MonoBehaviour
{
    public GameObject dialogue;
    public void LoadGameFile()
    {
        StreamReader sr = new StreamReader("C:/tmp/SaveFile_ProjektTM.dat");
        string data = sr.ReadToEnd();
        sr.Close();
        XmlSerializer serializer = new XmlSerializer(data.GetType());
        MemoryStream streamer = new MemoryStream();
        streamer.Seek(0, SeekOrigin.Begin);
        streamer.Write(System.Text.Encoding.UTF8.GetBytes(data), 0, System.Text.Encoding.UTF8.GetBytes(data).Length);
        streamer.Seek(0, SeekOrigin.Begin);
        string loaded = (string)serializer.Deserialize(streamer);
        string[] items = loaded.Split(';');
        PlayerStats stats = GlobalControl.Instance.Player.GetComponent<PlayerStats>();
        stats.Level = System.Convert.ToInt32(items[0]);
        stats.CurrEXP = System.Convert.ToInt32(items[1]);
        stats.ExperienceToNextLvl = System.Convert.ToInt32(items[2]);
        stats.StatPoints = System.Convert.ToInt32(items[3]);
        stats.Vitality = System.Convert.ToInt32(items[4]);
        stats.Agility = System.Convert.ToInt32(items[5]);
        stats.Strength = System.Convert.ToInt32(items[6]);
        stats.Defense = System.Convert.ToInt32(items[7]);
        stats.HealthPoints = System.Convert.ToInt32(items[8]);
        stats.MaxHP = System.Convert.ToInt32(items[9]);
        stats.HealthRegen = System.Convert.ToInt32(items[10]);
        stats.MoveSpeed = System.Convert.ToDecimal(items[11]);
        stats.AttackSpeed = System.Convert.ToDecimal(items[12]);
        stats.Dodge = System.Convert.ToDecimal(items[13]);
        stats.Armor = System.Convert.ToInt32(items[14]);
        stats.Damage = System.Convert.ToInt32(items[15]);
        stats.Helmet = System.Convert.ToInt32(items[16]);
        stats.Pauldrons = System.Convert.ToInt32(items[17]);
        stats.Breastplate = System.Convert.ToInt32(items[18]);
        stats.Belt = System.Convert.ToInt32(items[19]);
        stats.RHand = System.Convert.ToInt32(items[20]);
        stats.LHand = System.Convert.ToInt32(items[21]);
        stats.Boots = System.Convert.ToInt32(items[22]);
        stats.Gold = System.Convert.ToInt32(items[23]);
        string currMap = (string)items[24];
        Vector3 pos = new Vector3((float)System.Convert.ToDouble(items[25]), (float)System.Convert.ToDouble(items[26]), (float)System.Convert.ToDouble(items[27]));
        GlobalControl.Instance.previousVisitedCity = items[28];
        GlobalControl.Instance.krolowa = System.Convert.ToInt32(items[29]);
        GlobalControl.Instance.starszy = System.Convert.ToInt32(items[30]);
        GlobalControl.Instance.straznike = System.Convert.ToInt32(items[31]);
        GlobalControl.Instance.straznikl = System.Convert.ToInt32(items[32]);
        GlobalControl.Instance.qLog = items[33];
        GlobalControl.Instance.Player.GetComponent<Actions>().CanWalk = true;
        GlobalControl.Instance.blacksmith.SetActive(false);
        dialogue.SetActive(false);
        gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name != currMap)
        {
            GetComponent<PlayerStats>().SaveState();
            SceneManager.LoadScene(currMap);
        }
        else
        {
            GlobalControl.Instance.Player.transform.SetPositionAndRotation(pos, new Quaternion(0, 0, 0, 0));
        }
    }
    public void SaveGameFile()
    {
        GlobalControl.Instance.Player.GetComponent<PlayerStats>().SaveState();
        GlobalControl data = GlobalControl.Instance;
        string saved = data.level + ";" + data.currEXP + ";" + data.experienceToNextLvl + ";" + data.statPoints + ";" + data.vitality + ";" + data.agility + ";" + data.strength + ";" + data.defense + ";" + data.healthPoints + ";" + data.maxHP + ";" + data.healthRegen + ";" + data.moveSpeed + ";" + data.attackSpeed + ";" + data.dodge + ";" + data.armor + ";" + data.damage + ";" + data.helmet + ";" + data.pauldrons + ";" + data.breastplate + ";" + data.belt + ";" + data.rHand + ";" + data.lHand + ";" + data.boots + ";" + data.gold + ";" + data.currMap + ";" + data.posX + ";" + data.posY + ";" + data.posZ + ";" + data.previousVisitedCity + ";" + data.krolowa + ";" + data.starszy + ";" + data.straznike + ";" + data.straznikl + ";" + data.qLog;
        FileStream fs = File.Create("C:/tmp/SaveFile_ProjektTM.dat");
        XmlSerializer serializer = new XmlSerializer(saved.GetType());
        MemoryStream streamer = new MemoryStream();
        serializer.Serialize(streamer, saved);
        streamer.Seek(0, SeekOrigin.Begin);
        fs.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);
        fs.Close();
    }
}
