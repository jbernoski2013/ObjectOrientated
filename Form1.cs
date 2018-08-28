using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Julia Bernoski
 * PROG2370 - Section 5
 * September 23rd 2017
 * Revision: September 24th 2017
 */

 
namespace JBernoskiAssignment1_2
{
	public partial class Form1 : Form
	{
		//SeatingChart
		string[,] seatingChart = new string[5, 3]
		{
			{ "A,0" ,"A,1","A,2" },
			{ "B,0" ,"B,1","B,2" },
			{ "C,0" ,"C,1","C,2" },
			{ "D,0" ,"D,1","D,2" },
			{ "E,0" ,"E,1","E,2" }
		};

		//Seating Array
		string[,] seatingArray = new string[5, 3];

		//Arrays for listboxs
		string[] seatArray = new string[3] { "0", "1", "2" };
		string[] rowArray = new string[5] { "A", "B", "C", "D", "E" };

		//Waiting Array
		string[] waitingArray = new string [10];

	
		public Form1()
		{
			InitializeComponent();

			//Insert Data into List Boxs
			for (int i = 0; i < rowArray.Length; i++)
			{
				lstRow.Items.Add(rowArray[i]);
			}
			for(int j = 0; j < seatArray.Length; j++)
			{
				lstSeat.Items.Add(seatArray[j]);
			}
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			//Chart for seating
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 3; j++)
				{

					rtbShowAll.Text += seatingChart[i, j] + "\n";
				}
			}
		}

		private void btnFillAll_Click(object sender, EventArgs e)
		{
			//Book all the seats
			int rowSelected = lstRow.SelectedIndex;
			int seatSelected = lstSeat.SelectedIndex;
			for (int i =0; i < 5; i++)
			{
				for(int j=0; j<3; j++)
				{
					seatingArray[i, j] = "Booked";
					rtbShowAll.Text += seatingArray[i, j] + "\n";
				}
			}

		}

		private void btnBook_Click(object sender, EventArgs e)
		{
			string name = txtName.Text;
			int selectedSeat = lstSeat.SelectedIndex;
			int selectedRow = lstRow.SelectedIndex;

			//check if seat is selected & if any seats are available
			if (lstRow.SelectedIndex == -1 && lstSeat.SelectedIndex == -1)
			{
				MessageBox.Show("Please select a seat");
			}
			//make sure name is entered
			else if (name == "")
			{
				MessageBox.Show("Please enter a name");
			}
			//if all seats are booked, move to waiting list
			else if (seatingArray[selectedRow, selectedSeat] == "Booked")
			{
				btnAddToWaiting_Click(sender, e);
			}
			//make sure seat is not taken
			else if (seatingArray[selectedRow, selectedSeat] != null)
			{
				MessageBox.Show("Seat Taken");
			}
			else
			//book seat
			{
				seatingArray[selectedRow, selectedSeat] = name;
				MessageBox.Show("Seat Booked");
				seatingChart[selectedRow, selectedSeat] = seatingArray[selectedRow, selectedSeat];
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			
			//find seat and delete name from seating
			int selectedRow = lstRow.SelectedIndex;
			int selectedSeat = lstSeat.SelectedIndex;

			//make sure seat is selected
			if (lstRow.SelectedIndex == -1 && lstSeat.SelectedIndex == -1)
			{
				MessageBox.Show("Please select a seat to be cancelled");
			}
			//no one is in seat
			else if (seatingArray[selectedRow, selectedSeat] == null)
			{
				MessageBox.Show("No one is in selected seat, please choose another seat");
			}
			//cancel seat and Add if anyone in waiting
			else
			{
				seatingArray[selectedRow, selectedSeat] = null;
				MessageBox.Show("Seat Cancelled");
				rtbShowAll.Refresh();

				//Move person from waiting array to the new seat available
				if(waitingArray[0] != null)
				{
					seatingArray[selectedRow, selectedSeat] = waitingArray[0];
					MessageBox.Show("Person in waiting list moved to seat");
					waitingArray[0] = waitingArray[1];
					waitingArray[1] = waitingArray[2];
					waitingArray[2] = waitingArray[3];
					waitingArray[3] = waitingArray[4];
					waitingArray[4] = waitingArray[5];
					waitingArray[5] = waitingArray[6];
					waitingArray[6] = waitingArray[7];
					waitingArray[7] = waitingArray[8];
					waitingArray[8] = waitingArray[9];
					waitingArray[9] = null;

				}

			}
			
		}

		private void btnShowWaiting_Click(object sender, EventArgs e)
		{
			if (waitingArray != null)
			{
				for (int i = 0; i < 10; i++)
				{
					rtbWaiting.Text += waitingArray[i] + "\n";
				}
			}
			else
			{
				MessageBox.Show("No one in waiting array");
			}
		}

		private void btnAddToWaiting_Click(object sender, EventArgs e)
		{
			string name = txtName.Text;
			
			if(name == null)
			{
				MessageBox.Show("Please enter a name!");
			}
			else
			{
				//Seats Avaiblable
				if (seatingArray == null)
				{
					MessageBox.Show("Seats are Available");
				}
				//Seats Not available
				else
				{
					if (waitingArray[0] == null)
					{
						waitingArray[0] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[1] == null)
					{
						waitingArray[1] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[2] == null)
					{
						waitingArray[2] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[3] == null)
					{
						waitingArray[3] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[4] == null)
					{
						waitingArray[4] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[5] == null)
					{
						waitingArray[5] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[6] == null)
					{
						waitingArray[6] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[7] == null)
					{
						waitingArray[7] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[8] == null)
					{
						waitingArray[8] = name;
						MessageBox.Show("Added to waiting list");
					}
					else if (waitingArray[9] == null)
					{
						waitingArray[9] = name;
						MessageBox.Show("Added to waiting list");
					}
					else
					{
						MessageBox.Show("Waiting List is full");
					}
				}
			}
		}

		private void btnStatus_Click(object sender, EventArgs e)
		{
			int rowSelected = lstRow.SelectedIndex;
			int seatSelected = lstSeat.SelectedIndex;
		
			
			if(lstRow.SelectedIndex == -1 && lstSeat.SelectedIndex == -1)
			{
				MessageBox.Show("You have to choose a seat in order to show status.");
			}
			else if(seatingArray[rowSelected,seatSelected] == null)
			{
				txtStatus.Text = "Available";
			}
			else
			{
				txtStatus.Text = "Unavailable";
			}
			
		}

		//accidently clicked stuff
		private void lstRow_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void Form1_Load_1(object sender, EventArgs e)
		{
			
		}
	}
}
