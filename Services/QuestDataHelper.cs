using ProustApp.Domain;

namespace ProustApp.Services;
public class QuestDataHelper
{
     #region 'Data Helper'
    
    public List<Questionnaire> Get()
    {
        var mockData = new List<Questionnaire>
        {
            GetMockData("1"),
            GetMockData("2"),
            GetMockData("3"),
            GetMockData("4")
        };

        return mockData; 
    }
    

    public Questionnaire GetMockData(string questionnaireId)
    {
        if(questionnaireId=="1") 
        {
            var questionnaire = new Questionnaire
            {
                qid = 1,
                Author = "Marcel Proust",
                Topic = "Original Proust Questionnaire",
                ResponseAuthor = "",
                Dialogs = new List<Dialog>
                {
                    { new Dialog("Your favourite virtue?","")},
                    { new Dialog("Your favourite qualities in a man?", "" )},
                    { new Dialog("Your favourite qualities in a woman?", "" )},
                    { new Dialog("Your chief characteristic?", "" )}, 
                    { new Dialog("What you appreciate the most in your friends?", "" )},
                    { new Dialog("Your main fault?", "" )},
                    { new Dialog("Your favourite occupation?", "" )},
                    { new Dialog("Your idea of happiness?", "" )},
                    { new Dialog("Your idea of misery?", "" )},
                    { new Dialog("If not yourself, who would you be?", "" )},
                    { new Dialog("Where would you like to live?", "" )},
                    { new Dialog("Your favourite colour?", "" )},
                    { new Dialog("Your favourite flower?", "" )},
                    { new Dialog("Your favourite bird?", "" )},
                    { new Dialog("Your favourite prose authors?", "" )},
                    { new Dialog("Your favourite poets?", "" )},
                    { new Dialog("Your favourite heroes in fiction?", "" )},
                    { new Dialog("Your favourite heroines in fiction?", "" )},
                    { new Dialog("Your favourite painters and composers?", "")}
                }
            };  

            return questionnaire;
        }
        if(questionnaireId=="2") 
        {
            var questionnaire = new Questionnaire
            {
                qid = 2,
                Author = "Marcel Proust",
                Topic = "Original Proust Questionnaire",
                ResponseAuthor = "Marcel Proust",
                Dialogs = new List<Dialog>
                {
                    { new Dialog("Your favourite virtue?", 
                    "The need to be loved; more precisely, the need to be caressed and spoiled much more than the need to be admired." )},
                    { new Dialog("Your favourite qualities in a man?", "Intelligence, moral sense.")},
                    { new Dialog("Your favourite qualities in a woman?", "Gentleness, naturalness, intelligence." )},
                    { new Dialog("Your chief characteristic?", "" )}, // @todo possibility to intentionally left blank
                    { new Dialog("What you appreciate the most in your friends?", "To have tenderness for me, if their personage is exquisite enough to render quite high the price of their tenderness." )},
                    { new Dialog("Your main fault?", "Not knowing, not being able to want " )},
                    { new Dialog("Your favourite occupation?", "Reading, daydreaming, writing verse, history, theater." )},
                    { new Dialog("Your idea of happiness?", "To live in contact with those I love, with the beauties of nature, with a quantity of books and music, and to have, within easy distance, a French theater. " )},
                    { new Dialog("Your idea of misery?", "Not to have known my mother or my grandmother." )},
                    { new Dialog("If not yourself, who would you be?", "Myself, as the people whom I admire would like me to be." )},
                    { new Dialog("Where would you like to live?", "A country where certain things that I should like would come true as though by magic, and where tenderness would always be reciprocated." )},
                    { new Dialog("Your favourite colour?", "The beauty is not in the colors, but in their harmony." )},
                    { new Dialog("Your favourite flower?", "All of them" )},
                    { new Dialog("Your favourite bird?", "The swallow." )},
                    { new Dialog("Your favourite prose authors?", "Currently, Anatole France,Pierre Loti., George Sand, Aug. Thierry." )},
                    { new Dialog("Your favourite poets?", "Baudelaire and Alfred de Vigny. Musset." )},
                    { new Dialog("Your favourite heroes in fiction?", "Hamlet, those of romance and poetry, those who are the expression of an ideal rather than an imitation of the real." )},
                    { new Dialog("Your favourite heroines in fiction?", "Bérénice, a woman of genius leading an ordinary life." )},
                    { new Dialog("Your favourite painters and composers?", "Beethoven, Wagner, Schumann, Meissonier, Mozart, Gounod.")}
                }
            };  

            return questionnaire;
        }
        
        else if(questionnaireId=="3") 
        {
            var questionnaire = new Questionnaire
            {
                qid = 3,
                Author = "George Plimpton",
                Topic = "Asking the sea",
                ResponseAuthor = "",
                Dialogs = new List<Dialog>
                {
                    { new Dialog("How long can you actually be productive on a daily basis? How do you know when to stop?", "" )},
                    { new Dialog("Age is my alarm clock, why do old men wake so early? Is it to have one longer day?", "" )},
                    { new Dialog("What is pain?", "")}
                }
            };  

            return questionnaire;
        }
        else if(questionnaireId=="4") 
        {
            var questionnaire = new Questionnaire
            {
                qid = 4,
                Author = "George Plimpton",
                Topic = "Asking the sea",
                ResponseAuthor = "Ernest Hemmingway",
                Dialogs = new List<Dialog>
                {
                    { new Dialog("How long can you actually be productive on a daily basis? How do you know when to stop?", 
                    "That's something you have to learn about yourself. The important thing is to work every day. I work from about seven until about noon. Then I go fishing or swimming, or whatever I want. The best way is always to stop when you are going good. If you do that you'll never be stuck. And don't think or worry about it until you start to write again the next day. That way your subconscious will be working on it all the time, but if you worry about it, your brain will get tired before you start again. But work every day. No matter what has happened the day or night before, get up and bite on the nail." )},
                    { new Dialog("Age is my alarm clock, why do old men wake so early? Is it to have one longer day?", "I don t know, all I know is that young boys sleep late and hard." )},
                    { new Dialog("What is pain?", "The most painful thing is losing yourself in the process of loving someone too much, and forgetting that you are special too.")}
                }
            };  

            return questionnaire;
        }
        else
        {
            return null;
        }
    }

    #endregion
}