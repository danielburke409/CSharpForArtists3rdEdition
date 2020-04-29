/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Runtime.Serialization;

[Serializable]
public class PersonVO {

	//enumeration
	public enum Sex {MALE, FEMALE}
	public enum Haircolor {UNKNOWN, BLONDE, BROWN, BLACK}

	// private instance fields
	private string   _firstName;
	private string   _middleName;
	private string   _lastName;
	private Sex      _gender;       
	private DateTime _birthday;
	[OptionalField]
	private Haircolor _hairColor;
	[OptionalField]
	private DateTime _dateSerialized;
	[OptionalField]
	private DateTime _dateDeserialized;

	//default constructor
	public PersonVO(){
		_firstName = string.Empty;
		_middleName = string.Empty;
		_lastName = string.Empty;
		_gender = Sex.MALE;
		_birthday = DateTime.Now;
		_hairColor = Haircolor.BLONDE;
	}

	public PersonVO(string firstName, string middleName, string lastName, 
									Sex gender, DateTime birthday, Haircolor hairColor){
		_firstName = firstName;
		_middleName = middleName;
		_lastName = lastName;
		_gender = gender;
		_birthday = birthday;
		_hairColor = hairColor;
	}

	// public properties
	public string FirstName {
		get { return _firstName; }
		set { _firstName = value; }
	}

	public string MiddleName {
		get { return _middleName; }
		set { _middleName = value; }
	}

	public string LastName {
		get { return _lastName; }
		set { _lastName = value; }
	}

	public Sex Gender {
		get { return _gender; }
		set { _gender = value; }
	}

	public DateTime Birthday {
		get { return _birthday; }
		set { _birthday = value; }
	}

	public int Age {
		get { 
			int years = DateTime.Now.Year - _birthday.Year;
			int adjustment = 0;
			if(DateTime.Now.Month < _birthday.Month){
				adjustment = 1;
			}else if((DateTime.Now.Month == _birthday.Month) && 
							(DateTime.Now.Day < _birthday.Day)){
							adjustment = 1;
						} 
		return years - adjustment;
		}
	}

	#region New Properties
	public Haircolor HairColor {
	  get { return _hairColor; }
		set { _hairColor = value; }
	}
	
	public DateTime DateSerialized {
	  get { return _dateSerialized; }
		set { _dateSerialized = value; }
	}
	
	public DateTime DateDeserialized {
	  get { return _dateDeserialized; }
		set { _dateDeserialized = value; }
	}
	#endregion
	
	public string FullName {
		get { return FirstName + " " + MiddleName + " " + LastName; }
	}

	public string FullNameAndAge {
		get { return FullName + " " + Age; } 
	}

	public override string ToString(){
		return FullName + " is a " + Gender + " who is " + Age + " years old " +
					 HairColor + " hair.\r\n -->Date Serialized: " + DateSerialized + 
					 ", Date Deserialized: " + DateDeserialized;
	}
	
	#region Custom Serialization Methods
	[OnSerializing]
	internal void OnSerializingMethod(StreamingContext context) {
	  _dateSerialized = DateTime.Now;
	}
	
	[OnDeserialized]
	internal void OnDeserialized(StreamingContext context) {
	  _dateDeserialized = DateTime.Now;
	}
	#endregion
} // end PersonVO class
