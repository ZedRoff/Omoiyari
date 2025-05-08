using UnityEngine;

public class StateScript : MonoBehaviour
{
    public State state {get; set;}
        public TextScript textScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.PreGame;
         textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) 
        {
            case State.Start:
                string[][] texts = new string[][]{
                new string[] { "Ford Benson ", "Ah, te voilà enfin réveillé... Luis Arcana. Ou devrais-je dire, 'volontaire numéro un' ?"},
                new string[] { "Ford Benson ", "Je suppose que tes collègues t'ont bien expliqué le principe de leur jouet ? Plonger dans un monde imaginaire, ressentir des émotions, des sensations... Sauf que, visiblement, ils ont oublié de te prévoir un billet retour." },
                new string[] { "Ford Benson ", "Tu ne reconnais pas l'endroit ? Normal. C'est ton propre esprit qui l'a créé. Enfin... modifié. Par moi. Je m'appelle Ford Benson. Tu ne me connais pas, mais moi, je connais très bien ton équipe. Et leur petit projet révolutionnaire."},
                new string[] { "Ford Benson ", "Trop 'handicapé' pour coder, trop 'lent' pour innover... C'est ce qu'ils ont dit, en tout cas. Alors j'ai décidé de leur donner une leçon. Et toi, tu es mon... cobaye volontaire." },
                new string[] { "Ford Benson ", "Ton seul moyen de sortir ? Me retrouver. Mais pour ça, il va falloir passer par mes épreuves. Des épreuves qui te montreront ce que c'est, vivre avec un handicap. Et si tu réussis, peut-être que je te libérerai." },
                new string[] { "Ford Benson ", "Alors, prêt à jouer ?" }


            };
            textScript.StartDialog(texts);
            state = State.WaitForTuto;
            break;
          
            case State.Pending:
                Debug.Log("pending state");
            break;
         
        }
    }
}
