using System;
using System.IO;
using UnityEngine;
using Firebaase;
using Firebase.Auth;
using Firebase.Unity.Editor;
using Firebase.Database;

public class databaseTraversal{ 
	FirebaseAuth _auth;
	FirebaseDatabase userRef = FirebaseDatabase.DefaultInstance;
	private static databaseTraversal _instance;
	private static readonly object padlock = new object();

	public databaseTraversal Instance{
		get{
			lock{
				if(_instance == null){
					_instance = new Profile();
					_instance.init();

					//note this init method can be made however the 
					//user of this structure desires
				}
			}
			return _instance;
		}
	}

	public void traverse(string name){
		FirebaseDatabase dbInstance = FirebaseDatabase.DefaultInstance;
		dbInstance.GetReference("Reference").GetValueAsync().ContinueWith(task => {
			if(task.IsCanceled){
				return;
			}

			if(task.IsFaulted){
				return;				
			}

			if(task.IsCompleted){
				DataSnapshot data = task.Result;
				foreach(DataSnapshot shot in data.Children){
					//data.Children holds the reference to the elements in the "Reference"
					//branch

					var info = data.Value as Dictionary<string, object>;
					foreach(var snap in info){
						//here we can access the sub elements of the 
						//reference sub branches

						//use the .Key method to get the string version of the databranch
						//use the .Value returns the data in the databranch

						//as an example ill have my data structured as
						/*Reference{
							"name":{
								"Age":
								"Birthday":
							}
						}*/
						if(info.Key == name){
							string age = (string)info.Value;

							Console.WriteLine("The user {0} is {1} years old", 
								info.Key, age);
						}
					}
				}
			}

			});
	}
}