﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateiverwaltung
{
    public class Backend
    {
        XML_IO xml;
        DataSet ds_Media;
        DataSet ds_Customers;
        List<Media> mediaList;
        List<Customer> customerList;
        Customer[] customers;


        public List<Customer> CustomerListe { get { return customerList; } }
        public List<Media> MedienListe { get { return mediaList; } }

        public Backend()
        {
            try
            {
                xml = new XML_IO();
                ds_Customers = xml.readCustomers();
                ds_Media = xml.readMedia();
                xml.readCustomers(out customers);
                //customerList = new List<Customer>();
                customerList = customers.ToList<Customer>();
                //ds_CustomersAuslesen();
                mediaList = new List<Media>();
                ds_MediaAuslesen();
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString(), "IOException");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString(), "Unknown Error");
            }
        }

        private void ds_CustomersAuslesen()
        {
            int i = 0;
            for (int j = 0; j < ds_Media.Tables[i].Rows.Count; j++) //Looped durch alle Reihen einer Tabelle
            {
                customerList.Add(new Customer(ds_Customers.Tables[i].Rows[j][0].ToString(), ds_Customers.Tables[i].Rows[j][1].ToString(), ds_Customers.Tables[i].Rows[j][2].ToString(), ds_Customers.Tables[i].Rows[j][0].ToString(), ds_Customers.Tables[i].Rows[j][3].ToString(), ds_Customers.Tables[i].Rows[j][4].ToString()));
            }
        }

        private void ds_MediaAuslesen() //Liest ds_Media aus und erstellt enthaltene Objekte, speichert diese in Liste
        {
            //ds_Media.Tables[x] 0 => Media, 1 => Books, 2 => EBook, 3 => CD, 4 => DVD, 5 => BluRay

            for (int i = 1; i < ds_Media.Tables.Count; i++) //Looped durch die verschiedenen Tabellen
            {
                for (int j = 0; j < ds_Media.Tables[i].Rows.Count; j++) //Looped durch alle Reihen einer Tabelle
                {
                    DataRow dr = ds_Media.Tables[i].Rows[j];
                    switch (i)
                    {
                        case 1: //BOOK
                            mediaList.Add(new Book(ds_Media.Tables[i].Rows[j][0].ToString(), ds_Media.Tables[i].Rows[j][1].ToString(), ds_Media.Tables[i].Rows[j][2].ToString(), ds_Media.Tables[i].Rows[j][3].ToString(), ds_Media.Tables[i].Rows[j][4].ToString(), ds_Media.Tables[i].Rows[j][5].ToString(), ds_Media.Tables[i].Rows[j][6].ToString(), ds_Media.Tables[i].Rows[j][7].ToString(), ds_Media.Tables[i].Rows[j][8].ToString()));
                                break;
                        case 2: //EBOOK
                            mediaList.Add(new EBook(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString()));
                            break;
                        case 3: //CD
                            mediaList.Add(new CD(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString()));
                            break;
                        case 4: //DVD
                            mediaList.Add(new DVD(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString()));
                            break;
                        case 5: //BluRay
                            mediaList.Add(new BluRay(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString()));
                            break;
                    }
                }
            }
        }

        //Form übergibt an diese methode daten zum erstellen eines Kunden
        public void addCustomer(string sVorname, string sNachname, string sStrasse, string sPLZ, string sOrt)
        {
            //Kunde hinzufügen
        }

        public void editCustomer()
        {
            //Here there be dragons!
        }

        public void saveAll() //Übergibt Medien- und Kundenliste an XML-Klasse zum Abspeichern
        {
            xml.saveMedia(mediaList);
            xml.saveCustomers(customerList);
        }

        #region Keep for now, Delete before Abgabe!
        public void test()
        {
            DateTime dt = new DateTime(1999, 05, 16);

            Media[] medArray = new Media[9];
            medArray[0] = new Book(15, "Stephen King", "Dark Tower", "Fantasy/Horror", dt);
            medArray[1] = new Book(32, "Douglas Adams", "Hitchhikers Guide to the Galaxy", "Fantasy", dt);
            medArray[2] = new Book(10238, "Gustapho Fring", "Los Pollos Hermanos", "Mexico", dt);
            medArray[3] = new EBook(482, "Jules Verne", "Reise zum Mittelpunkt der Erde", "SciFi", dt);
            medArray[4] = new EBook(47, "Edgar Allan Poe", "Der Rabe", "Horror", dt);
            medArray[5] = new EBook(794, "Jesus Christus", "Die Lutherbibel", "Fantasy", dt);
            medArray[6] = new CD(123, "Monstercat", "30 - Finale", "EDM", dt);
            medArray[7] = new CD(34, "JayZ", "It's a hard knock life", "HipHop", dt);
            medArray[8] = new CD(74, "Gustave Le Bon", "Psychologie der Massen", "Buch", dt);
            //medArray[9] = new DVD();
            //medArray[10] = new DVD();
            //medArray[11] = new DVD();
            //medArray[12] = new BluRay();
            //medArray[13] = new BluRay();
            //medArray[14] = new BluRay();
        }
        #endregion
    }
}
