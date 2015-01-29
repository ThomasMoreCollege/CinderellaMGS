using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinderellaLauncher
{
    class MatchMakingLogic//class for handling the matchmaking
    {
        //MakeMatch
        //handles a single matchmaking attempt
        //Input: queued cinderellas and godmothers, and empty lists for them, to be added to.
        //Output: Lists are updates with the matches
        //preconditions: the lists that are past are without error, complete in the data that they should contain, and none of them have been matched
        //Postconditions: the cinderellas have been amtched are moved to the matched lists
        public void MakeMatch(ref List<CinderellaClass> CinderellaQueue, ref List<FairyGodmother> GodMotherQueue, ref List<CinderellaClass> MatchedCinderellas, ref List<FairyGodmother> MatchedGodMother)
        {
                //Create two objects to hold the cinderellas and godmothers at the head of the queue
                CinderellaClass Cinderella = new CinderellaClass();
                FairyGodmother GodMother = new FairyGodmother();
                //get the cinderella at the head of the queue
                Cinderella = CinderellaQueue[0];
                //do the same for the godmother
                if (GodMotherQueue.Count > 0)
                {
                    GodMother = GodMotherQueue[0];
                }
                else
                {
                    GodMother = null;
                }
                //handle the best case, not special needs, no requested godmother
                if ((Cinderella.SpecialNeeds == false) && (Cinderella.RequestedGodMother == 0))
                {
                    if (GodMother != null)
                    {//deqeue the cinderella and god mother and add the match to thier appropiate lists
                        MatchedCinderellas.Add(Cinderella);
                        CinderellaQueue.RemoveAt(0);
                        MatchedGodMother.Add(GodMother);
                        GodMotherQueue.RemoveAt(0);
                    }
                }
                //special needs, no requested godmother
                if ((Cinderella.SpecialNeeds == true) && (Cinderella.RequestedGodMother == 0))
                {
                    int id = FindSpecialGodMother(ref GodMotherQueue);
                    if ((GodMother != null) && (0 > -1))//there is an availible godmother that can handle special needs
                    {
                        MatchedCinderellas.Add(Cinderella);
                        CinderellaQueue.RemoveAt(0);//deqeue cinderella
                        MatchedGodMother.Add(GodMotherQueue[id]);
                        GodMotherQueue.RemoveAt(id);//deqeue GodMother
                    }
                }
                //requested godmother
                if (Cinderella.RequestedGodMother != 0)
                {
                    if (GodMother != null)
                    {
                        int id = FindGodMotherByID(Cinderella.RequestedGodMother, ref GodMotherQueue);
                        if (id > -1)
                        {//the Requested GodMother is availible
                            MatchedCinderellas.Add(Cinderella);
                            CinderellaQueue.RemoveAt(0);//deqeue cinderella
                            MatchedGodMother.Add(GodMotherQueue[id]);
                            GodMotherQueue.RemoveAt(id);//deqeue GodMother
                        }
                        else
                        {//the GodMother is not availible at the moment

                        }
                    }
            }
        }

        //FindSpecialGodMother
        //finds the first godmother that can handle special needs and returns the index
        //Input: lists of godmother sthat are in the queue or -1 if not found
        //Output:the index of the first found god mother that can handle special  needs
        //preconditions: the list is and accurate and contains only god mothers
        //postconditions: either an id of a god mother is returned or -1 signifying none found is returned
        public int FindSpecialGodMother(ref List<FairyGodmother> GodMotherQueue)
        {
            int index = 0;
            foreach (FairyGodmother GodMother in GodMotherQueue)//loops through all the fairy godmothers
            {
                if (GodMother.CanHandleSpecialNeeds == true)
                {
                    //godmother found
                    return index;
                }
                index += 1;
            }
            return -1;//a.k.a. not found
        }

        //FindGodMotherByID
        //returns the index of the GodMother with the passes id value
        //Input: the ID of the godmother and a list that contains the god mother
        //Output: the index of the godmother or -1 if not found
        //preconsitions: the list cotains only godmothers
        //postconditions: either the index of the god mother is returned or -1 signifying none found is returned
        public int FindGodMotherByID(int ID, ref List<FairyGodmother> GodMotherQueue)//this ID will have been retreived from the request form
        {
            SQL_Queries debugging = new SQL_Queries();
            int index = 0;
            foreach (FairyGodmother GodMother in GodMotherQueue)
            {
                if (GodMother.getFairyID() == ID) //Gets the Fairy Godmother ID.
                {
                    //returns index if a Fairy Godmother is found. [A fairy Godmother was found.]
                    return index;
                }
                index += 1;
            }
            return -1;//If this line occurs then something has gone wrong. [No Fairy Godmother was found.] 
        }
    }
}
