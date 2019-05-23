using System.Collections.Generic;
using UnityEngine;

namespace Eliot.Environment
{
	/// <summary>
	/// The buffer of object's characteristics that Agent can easily understand.
	/// Add Unit component to all the objects that you want Agent to interract well with.
	/// </summary>
	public class Unit : MonoBehaviour
	{
		/// <summary>
		/// User-defined type of the unit. Depends highly on the context of the game.
		/// </summary>
		public UnitType Type
		{
			get { return _type;}
			set { _type = value;} 
		}
		
		/// <summary>
		/// Team to which the unit belongs.
		/// </summary>
		public string Team
		{
			get { return _team;}
			set { _team = value;} 
		}
		
		/// User-defined type of the unit. Depends highly on the context of the game.
		[SerializeField] private UnitType _type;
		/// Team to which the unit belongs.
		[SerializeField] private string _team;
		/// Names of teams that are concidered friendly to this unit.
		[SerializeField] private List<string> _friendTeams = new List<string>();

		/// <summary>
		/// Check wheather the given unit belongs to the same team or to one of the friendly teams.
		/// </summary>
		/// <param name="unit"></param>
		/// <returns></returns>
		public bool IsFriend(Unit unit)
		{
			return _team == unit._team || _friendTeams.Contains(unit._team);
		}
	}
}