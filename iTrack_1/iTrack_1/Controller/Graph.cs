using iTrack.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrack_1
{
    class Graph
    {
        public List<CameraInfo> nodes;
        private int count;
        public Graph()
        {
            nodes=new List<CameraInfo>();
        }
        public void add(string name, string ip, double degree, List<string> neighbours)
        {
            nodes.Add(new CameraInfo(name, ip, degree, neighbours));
        }
        //
        public void add(string name, string ip, double degree, List<string> neighbours,string username,string pwd)
        {
            nodes.Add(new CameraInfo(name, ip, degree, neighbours,username,pwd));
        }

        public void add(string name, string ip, double degree, List<string> neighbours, string username, string pwd, int reg, int ide, int tr)
        {
            nodes.Add(new CameraInfo(name, ip, degree, neighbours, username, pwd, reg, ide, tr));
        }


        public void add(string name, string ip, double degree, List<string> neighbours, string username, string pwd,int reg,int ide,int tr,int od)
        {
            nodes.Add(new CameraInfo(name, ip, degree, neighbours, username, pwd,reg,ide,tr,od));
        }

        public void add(string name, string ip, double degree, List<string> neighbours, string username, string pwd, int reg, int ide, int tr, int od,string odneighbour)
        {
            nodes.Add(new CameraInfo(name, ip, degree, neighbours, username, pwd, reg, ide, tr, od,odneighbour));
        }

        public void update( string ip, double degree, List<string> neighbours,int turn)
        {
            nodes[turn].IP = ip;
            nodes[turn].degree = degree;
            nodes[turn].neighbours = neighbours;

        }
        public void update(string ip, double degree, List<string> neighbours, int turn,string username,string pwd)
        {
            nodes[turn].neighbours = neighbours;
            nodes[turn].IP = ip;
            nodes[turn].degree = degree;
            nodes[turn].user = username;
            nodes[turn].password=pwd;

        }

        public void update(string ip, double degree, List<string> neighbours, int turn, string username, string pwd,int reg, int ide, int tr, int od,string odneighbour)
        {
            nodes[turn].neighbours = neighbours;
            nodes[turn].IP = ip;
            nodes[turn].degree = degree;
            nodes[turn].user = username;
            nodes[turn].password = pwd;
           
            // under making 

        }

        public int find (string name)
        {
            return 0; 
        }
        public List<string> getneighbour (int cameranum)
        {
            List<string> str= nodes[cameranum].neighbours;
            return str;
        }
        public int numberofcameras()
        {
            return nodes.Count;
        }
        public string getName(int i)
        {
            return nodes[i].name;
        }
        public string getodNeighbour(int i)
        {
            return nodes[i].ODneighbour;
        }
        public bool getReg(int i)
        {
            return nodes[i].Registration;
        }
        public bool getIden(int i)
        {
            return nodes[i].Identification;
        }
        public bool getTrack(int i)
        {
            return nodes[i].Tracking;
        }
        public bool getOD(int i)
        {
            return nodes[i].OD;
        }
        public void setOD(int i,bool disicion)
        {
             nodes[i].OD=disicion;
        }
        public string getip(int i)
        {
            return nodes[i].ip;
        }
        public double getRotation(int i)
        {
            return nodes[i].degree;
        }
        public string getUserName(int i)
        {
            return nodes[i].user;
        }
        public string getPwd(int i)
        {
            return nodes[i].password;
        }
        public void addneighbour(string neightbour,int cameranum)
        {
            nodes[cameranum].neighbours.Add(neightbour);
        }
        public void removeneighbour (string neighbourRemove, int cameranum)
        {
            nodes[cameranum].neighbours.Remove(neighbourRemove);
        }

    }
    class node
    {
        public string name{get;set;}
        public string ip { get; set; }
        public double degree { get; set; }
        public List<String> neighbours { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public node (string name,string ip,double degree,List<string>neighbours)
        {
            this.name=name;
            this.ip=ip;
            this.degree=degree;
            this.neighbours=neighbours;
        }


    }
}
