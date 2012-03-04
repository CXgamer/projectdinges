﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace MotoroziodDB
{
    /// <summary>
    /// Klasse om de Machine objecten weg te schrijven in de database of de database te halen
    /// </summary>
    /// <author>Wim Baens</author>
    public class MachineDB
    {
        /// <summary> 
        /// update de machinedata in database
        /// </summary>
        /// <param name="machines">lijst gevuld met Machine objecten</param>        
        /// <author>Brecht Derwael</author>  
        public static void updateMachineData(List<Machine> machines)
        {
            SqlCommand updateCommand;
            string updateStatement;
            SqlConnection conn = ConnectionDB.getConnection();

            try
            {
                conn.Open();

                foreach (Machine m in machines)
                {
                    updateStatement = "UPDATE Machines " +
                                    "SET Naam = @Naam, " +
                                    "TypeId = @TypeID, " +
                                    "Label = @Label, " +
                                    "Vermogen = @Vermogen, " +
                                    "Tnom = @Tnom, " +
                                    "Nnom = @Nnom " +
                                    "WHERE MachineID = @MachineID";
                    updateCommand = new SqlCommand(updateStatement, conn);
                    updateCommand.Parameters.AddWithValue("@Naam", m.MachineNaam);
                    updateCommand.Parameters.AddWithValue("@TypeID", m.TypeId);
                    updateCommand.Parameters.AddWithValue("@Label", m.Label);
                    updateCommand.Parameters.AddWithValue("@Vermogen", m.Vermogen);
                    updateCommand.Parameters.AddWithValue("@Tnom", m.NominaalKoppel);
                    updateCommand.Parameters.AddWithValue("@Nnom", m.NominaalToerental);
                    updateCommand.Parameters.AddWithValue("@MachineID", m.MachineId);

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary> 
        /// Haalt Machine objecten volgens bestandpad op met alles ingevuld
        /// </summary>
        /// <param name="pad">tekst</param> 
        /// <returns>lijst met Machine objecten</returns>
        /// <author>Wim Baens</author>  
        public static List<Machine> getMachines(String pad)
        {
            List<Machine> machines = new List<Machine>();

            SqlConnection conn = ConnectionDB.getConnection();
            string selectStatement;
            SqlCommand selectCommand;

            selectStatement = "SELECT Machines.MachineID, Machines.BesteNominaalID, Machines.Naam,Machines.TypeID,Machines.Label,Machines.Vermogen,Machines.Tnom,Machines.Nnom " +
                            "FROM Machines INNER JOIN MachineBestand ON MachineBestand.MachineID=Machines.MachineID " +
                            "WHERE MachineBestand.BestandPad=@BestandPad";
            selectCommand = new SqlCommand(selectStatement, conn);
            selectCommand.Parameters.AddWithValue("@BestandPad", pad);

            try
            {
                conn.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Machine machine = new Machine(reader["Naam"].ToString(), Convert.ToInt32(reader["MachineID"]));
                    machine.TypeId = Convert.ToInt32(reader["TypeID"]);
                    machine.Label = reader["Label"].ToString();
                    machine.Vermogen = Convert.ToDouble(reader["Vermogen"]);
                    machine.NominaalKoppel = Convert.ToDouble(reader["Tnom"]);
                    machine.NominaalToerental = Convert.ToDouble(reader["Nnom"]);
                    machine.BesteNominaalID = Convert.ToInt32(reader["BesteNominaalID"]);
                    machines.Add(machine);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return machines;
        }
    }
}