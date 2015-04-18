<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        CinderellaQueue.CinderellaQueue cinderellaAutomatedQueue = new CinderellaQueue.CinderellaQueue();
        CinderellaQueue.CinderellaQueue cinderellaManualQueue = new CinderellaQueue.CinderellaQueue();
        VolunteerQueue.VolunteerQueue volunteerQueue = new VolunteerQueue.VolunteerQueue();

        Application.Add("cinderellaAutomatedQueue", cinderellaAutomatedQueue);
        Application.Add("cinderellaManualQueue", cinderellaManualQueue);
        Application.Add("volunteerQueue", volunteerQueue);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        conn.Open();
        
        // CHECKING FOR WAITING CINDERELLA AND ADDING THEM TO THE PAIRING QUEUE

        // SQL string to retrieve all Cinderellas currently waiting to be paired
        string sql = "SELECT CinderellaID, isManuallyPaired "
                    + "FROM Cinderella "
                    + "INNER JOIN CinderellaStatusRecord "
                    + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                    + "WHERE IsCurrent = 'Y' "
                        + "AND Status_Name = 'Waiting for Godmother' "
                        + "AND isManuallyPaired = 'Y'";
        
        // Execute SQL
        SqlCommand CinderellasComm = new SqlCommand(sql, conn);
        
        //Create a new adapter
        SqlDataAdapter CinderellaAdapter = new SqlDataAdapter(CinderellasComm);

        //Create a new dataset to hold the query results
        DataSet CinderellaDataSet = new DataSet();

        //Store the results in the adapter 
        CinderellaAdapter.Fill(CinderellaDataSet);

        for (int i = 0; i < CinderellaDataSet.Tables[0].Rows.Count; i++)
        {
            try
            {

                //Retrieve ID of selected volunteer
                int cinID = Convert.ToInt32(CinderellaDataSet.Tables[0].Rows[i]["CinderellaID"]);

                //Create object instance with selected volunteer
                CinderellaClass databseCinderella = new CinderellaClass(cinID);

                //Lock application state so that no else can access it 
                Application.Lock();

                //Initialize a local copy of volunteer queue
                CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

                //Copy queue in the application session into the local copy
                cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

                //Insert volunter to the queue
                cinderellaAutomatedQueueCopy.priorityEnqueue(databseCinderella);

                //Copy changes into application queue
                Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

                //Unlock Application session
                Application.UnLock();
            }
            catch
            {

            }
        }
        
        // CHECKING FOR READY VOLUNTEERS (GODMOTHERS!) AND ADDING THEM TO THE QUEUE

        // SQL string to retrieve all Volunteers currently waiting to be paired
        sql = "SELECT VolunteerID, Role_Name "
                    + "FROM Volunteer "
                    + "INNER JOIN VolunteerRoleRecord "
                    + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                    + "INNER JOIN VolunteerStatusRecord "
                    + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                    + "WHERE VolunteerRoleRecord.IsCurrent = 'Y' "
                            + "AND Role_Name = 'Godmother' "
                            + "AND VolunteerStatusRecord.IsCurrent = 'Y' "
                            + "AND Status_Name = 'Ready'";

        // Execute SQL
        SqlCommand volunteersComm = new SqlCommand(sql, conn);

        //Create a new adapter
        SqlDataAdapter VolunteerAdapter = new SqlDataAdapter(volunteersComm);

        //Create a new dataset to hold the query results
        DataSet VolunteerDataSet = new DataSet();

        //Store the results in the adapter 
        VolunteerAdapter.Fill(VolunteerDataSet);

        for (int i = 0; i < VolunteerDataSet.Tables[0].Rows.Count; i++)
        {  
            try
            {

                //Retrieve ID of selected volunteer
                int volID = Convert.ToInt32(VolunteerDataSet.Tables[0].Rows[i]["VolunteerID"]);

                //Create object instance with selected volunteer
                VolunteerClass databaseVolunteer = new VolunteerClass(volID);

                //Lock application state so that no else can access it 
                Application.Lock();

                //Initialize a local copy of volunteer queue
                VolunteerQueue.VolunteerQueue volunteerAutomatedQueueCopy = new VolunteerQueue.VolunteerQueue();

                //Copy queue in the application session into the local copy
                volunteerAutomatedQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

                //Insert volunter to the queue
                volunteerAutomatedQueueCopy.enqueue(databaseVolunteer);

                //Copy changes into application queue
                Application["volunteerQueue"] = volunteerAutomatedQueueCopy;

                //Unlock Application session
                Application.UnLock();
            }
            catch
            {

            }
        }

        //Close Connection
        conn.Close();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
