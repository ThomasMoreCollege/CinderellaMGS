using System;
using System.Drawing;
using System.Drawing.Printing;
namespace IDAutomation_FontEncoder
{
/// © Copyright 2005, IDAutomation.com, Inc. All rights reserved.
/// Redistribution and use of this code in source and/or binary 
/// forms, with or without modification, are permitted provided 
/// that: (1) all copies of the source code retain the above 
/// unmodified copyright notice and this entire unmodified 
/// section of text, (2) You or Your organization owns a valid 
/// Developer License to this product from IDAutomation.com 
/// and, (3) when any portion of this code is bundled in any 
/// form with an application, a valid notice must be provided 
/// within the user documentation, start-up screen or in the 
/// help-about section of the application that specifies 
/// IDAutomation.com as the provider of the Software bundled 
/// with the application.

	/// <summary>
	/// Summary description for clsBarCode.
	/// </summary>
	public class clsBarCode
	{
		//Constants for this class
		private const int ASCII_START128_A = 203;		//Start character for Code128 Char Set A
		private const int ASCII_START128_B = 204;		//Start character for Code128 Char Set B
		private const int ASCII_START128_C = 205;		//Start character for Code128 Char Set C
		private const int ASCII_FNC1_128 = 202;			//FNC1 character for Char Set C 
		private const int ASCII_STOP128 = 206;			//Stop character for all Code128 character sets
		private const int ASCII_SWITCH_TO_C = 199;		//Character for switching to character set C
		private const int ASCII_SWITCH_TO_A = 201;		//Charcter for switchting to character set A
		private const int ASCII_SWITCH_TO_B = 200;		//Charcter for switchting to character set B
		private const int ASCII_SPACE_CHAR = 194;		//Space replacement character 
		private const char CODABAR_START_CHAR = 'A';	//Start character for codabar
		private const char CODABAR_STOP_CHAR = 'B';		//Start character for codabar
		private const int ASCII_START_I2OF5 = 203;		//Start character for Interleaved 2 of 5
		private const int ASCII_STOP_I2OF5 = 204;		//Stop character for Interleaved 2 of 5
		private const string DOUBLE_ZEROES = "00";		//Special characters that must be accounted for
		private const int CHECK_DIGIT_MOD = 103;		//This is what we divide by to get the check digit
		private enum enuEncodingType :short 
		{
			EncodingA = 1,
			EncodingB = 2,
			EncodingC = 3
		};
		
		//This is the font object that is passed between the print method and the print
		//event handler
		private Font lclFont;
		//This is the text that will be printed from the printing event handler
		private string TextToPrint;

		public clsBarCode()
		{

		}

		/// <summary>
		/// calculates a mod 10 check digit from the input string
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private string FindMod10Digit(string input)
		{
			int remainder;
			int M10Factor = 0;
			int M10WeightedTotal = 0;
			int M10StringLength = 0;
			int M10I = 0;
			
			M10Factor = 3;
			M10WeightedTotal = 0;
			M10StringLength = input.Length;;
			for(M10I = M10StringLength;M10I > 0;M10I--)
			{
				//Get the value of each number starting at the end
				//multiply by the weighting factor which is 3,1,3,1...
				//and add the sum together
				M10WeightedTotal = M10WeightedTotal + Convert.ToInt32(input.Substring(M10I - 1, 1)) * M10Factor;
				//change factor for next calculation
				M10Factor = 4 - M10Factor;
			}
			remainder = M10WeightedTotal % 10;
			if (remainder == 0)
			{
				// Zero is the smallest remainder of 10
				return "0";  
			}
			else
			{
				//return (char) ((10 - remainder) + 48);  //the ASCII value follows sequentially after 48
				return (10 - remainder).ToString();
			}
		} //end FindMod10Digit()
		
		/// <summary>
		/// Interprets tilde characters for special processing.  
		/// </summary>
		/// <param name="InputValue"></param>
		/// <returns></returns>
		private string Code128TildeProcessing(string InputValue)
		{
			#region Tilde Processing
			string ActualInputValue = "";  //this is what we are going to return
			//Loop thru looking for a tilde
			int LenDataToEncode = InputValue.Length;
			for(int idx = 0;idx < LenDataToEncode;idx++)
			{
				if(InputValue.Substring(idx, 1).Equals("~") == true && ((LenDataToEncode - idx) > 3))
				{
					//We are either doing mod 10 processing or we are doing regular tilde processing to pull the ascii value
					if(InputValue.Substring(idx + 1, 1).Equals("m") == true)  //we are doing mod 10
					{
						try
						{
							int tempValue = Convert.ToInt32(InputValue.Substring(idx + 2, 2));
							if(tempValue > 0 && tempValue <= idx)  //make sure that they aren't going over the number of characters left in the string
							{
								//total number of characters before tilde.  We want to skip any non-numeric characters 
								//when taking into account the number of characters to go back.  Meaning if they try to
								//encode 1234A567~m06, we would calculate the mod 10 digit by using 234567.
								string StringToCheck = InputValue.Substring(0, idx);
								string StringToCalculate = "";
								for(int jdx = StringToCheck.Length;jdx >= 0; jdx--)
								{
									if(IsNumber(StringToCheck.Substring(jdx - 1, 1)) == true)
									{
										StringToCalculate += StringToCheck.Substring(jdx - 1, 1);
										if(StringToCalculate.Length == tempValue) //we've got all we need
											break;
									}
								}				
								
								//We now have a string of data that we can calculate a mod 10 check digit with
								if(StringToCalculate.Length == tempValue)
								{
									//StrintToCalculate is backwards.  flip it
									System.Text.StringBuilder revString = new System.Text.StringBuilder();
									for(int rev = StringToCalculate.Length;rev > 0;rev--)
										revString.Append(StringToCalculate.Substring(rev - 1, 1));
									
									ActualInputValue += FindMod10Digit(revString.ToString());
									idx += 3;
								}
								else //not the correct number of characters
									ActualInputValue += InputValue.Substring(idx, 1);
							}
							else
								ActualInputValue += InputValue.Substring(idx, 1);
						}
						catch
						{
							ActualInputValue += InputValue.Substring(idx, 1);
						}
					}
					else if(InputValue.Substring(idx + 1, 1).Equals("~") == true)
					{
						//The user really just wants to encode a tilde
						ActualInputValue += InputValue.Substring(idx, 1);
						idx++;
					}
					else //we're looking at pulling an ascii value
					{
						try
						{
							int tempValue = Convert.ToInt32(InputValue.Substring(idx + 1, 3));
							if(tempValue > 0 && tempValue <= 255)
							{
								ActualInputValue += ((char)tempValue).ToString();
								idx += 3;
							}
							else
								ActualInputValue += InputValue.Substring(idx, 1);
						}
						catch
						{
							ActualInputValue += InputValue.Substring(idx, 1);
						}
					}
				}
				else
					ActualInputValue += InputValue.Substring(idx, 1);
			}
			
			#endregion
			return ActualInputValue;
		} //end Code128TildeProcessing()
		
		/// <summary>
		/// This method will automatically generate the correct version of Code 128 bar code
		/// add switch between the different character sets.  It will take the Input string,
		/// add the start character, stop character, and check digit character and return the 
		/// completed string 
		/// </summary>
		/// <param name="InputValue">The value to barcode</param>
		/// <param name="InputValue">whether or not tildes are processed as special escape characters</param>
		/// <returns></returns>
		public string Code128(string InputValue, bool applyTilde)
		{
			/* There are 3 different character sets for Code128, A, B, & C.  Code A allows for uppercase 
			characters, punctuation, numbers and several special functions such as a return or tab.  
			Code B encodes everything from ASCII 32 to ASCII 126. It allows for upper and lower case 
			letters, punctuation, numbers and a few select functions.  Code C  encodes only numbers and 
			the FNC1 function. Because the numbers are "interleaved" into pairs, two numbers are encoded 
			into every barcode character which makes it a very high density barcode. If the number to 
			encode is not an even number, a leading zero should be added.  */

			string EncodedData = "";		//This is the resulting data after processing the InputValue
			int LenDataToEncode = 0;		//Length of InputValue
			int idx = 0;					//for loop counter
			int AscCharacter = 0;			//Ascii value of a particular character
			char[] ChrArray;				//Character array used to determine ASCII values
			char OutStartCharacter = ' ';	//character representing the start character of the output string
			char OutStopCharacter;	//character representing the start character of the output string
			char OutCheckCharacter;	//character representing the check digit for the data
			bool AsciiFnc1Found;			//Determines logic path in for loop if the FNC1 character is found
			string CurrentChars;			//This is the character(s) that we are currently evaluating in the for loop
			int WeightedTotal = 0;			//This is the value calculate to obtain the check digit 
			enuEncodingType EncodingType = enuEncodingType.EncodingA;   //type of character encodeing that we are doing
			int iCheckDigitValue = 0;		//Value returned from WeightedTotal mod function
			
			string ActualInputValue = "";	//value of input string after tilde processing
			if(applyTilde == true)
				ActualInputValue = Code128TildeProcessing(InputValue);
			else
				ActualInputValue = InputValue;

			//Here we select character set A, B or C for the START character
			LenDataToEncode = ActualInputValue.Length;
			
			//In order to get the ASCII value of the character, we move the first character
			//in the character array associated w/ the input string.  We then explicitly cast 
			//it to an int data type.  
			ChrArray = ActualInputValue.ToCharArray(0,1);
			AscCharacter = (int) ChrArray[0];
			
			//Determine the Code set of 128
			if(AscCharacter < 32)		//Automatically has to be Code A
			{
				OutStartCharacter = (char) ASCII_START128_A;
				EncodingType = enuEncodingType.EncodingA;
			}
			
			if((AscCharacter > 31 && AscCharacter < 127) || AscCharacter == 197) 
			{
				OutStartCharacter = (char) ASCII_START128_B;
				EncodingType = enuEncodingType.EncodingB;
			}

			//Check and see if the first 4 digits are numbers.  Since Code C is pairs of interleaved numbers
			if(LenDataToEncode > 4 && IsNumber(ActualInputValue.Substring(0, 4))==true)
			{	
				OutStartCharacter = (char) ASCII_START128_C;
				EncodingType = enuEncodingType.EncodingC; 
			}

			if(AscCharacter == ASCII_FNC1_128 || (AscCharacter > 211 && AscCharacter < 218)) //202 is the FNC1, with this Start C is mandatory
			{
				OutStartCharacter = (char) ASCII_START128_C;
				EncodingType = enuEncodingType.EncodingC;
			}
			
			//Set the stop character of the string 
			OutStopCharacter = (char) ASCII_STOP128;
			
			//loop through all characters and determine if we need to switch character sets or encode 
			//special functions
			for(idx = 0;idx < LenDataToEncode;idx++)
			{
				//check for FNC1 in any set
				AsciiFnc1Found=false;
				
				//Get the Ascii value of the current letter

				ChrArray = ActualInputValue.ToCharArray(idx, 1);
				AscCharacter = (int) ChrArray[0];
				if(AscCharacter == ASCII_FNC1_128 || (AscCharacter > 211 && AscCharacter < 218) )
				{
					// Format and print various data:
					//If we get here we bypass the next set of if statements.

					AsciiFnc1Found = true;
					//Add the FNC1 character to the output string 
					EncodedData = EncodedData + ((char) ASCII_FNC1_128);
				}    
				//Checking for switch to character set C.  In order to determine if we are switching to 
				//set C, we are checking if we have more than 2 characters left to check, & the digit is 
				//a number & the next character is a number and the ongoing 4 characters constitue a number 
				//OR
				//we are checking that this is not the last item, and the current char is a number, and 
				//the next character is a number and we are already encodint with Set C.
				//AND
				//AsciiFnc1Found = false  -- 
				if( ((idx <= (LenDataToEncode - 4)) && (IsNumber(ActualInputValue.Substring(idx,1)) == true) && 
					(IsNumber(ActualInputValue.Substring(idx + 1,1)) == true) && 
					(IsNumber(ActualInputValue.Substring(idx, 4)) == true )) || 
					((idx < LenDataToEncode - 1) && (IsNumber(ActualInputValue.Substring(idx, 1)) == true) && 
					(IsNumber(ActualInputValue.Substring(idx + 1, 1)) == true) && (EncodingType == enuEncodingType.EncodingC) ) 
					&& (AsciiFnc1Found == false) )
				{	
					//check for switching to character set C
					//switch to set C if not already in it
					if( EncodingType != enuEncodingType.EncodingC )
					{
						//Add the switch to set C character 
						EncodedData = EncodedData + ((char) ASCII_SWITCH_TO_C);
					} //End check for type c

					EncodingType = enuEncodingType.EncodingC;

					//We need to check for double zeros
					CurrentChars = ActualInputValue.Substring(idx, 2);
					if(CurrentChars == DOUBLE_ZEROES)
					{
						AscCharacter = ASCII_SPACE_CHAR;
					}	//if checking for 00
					else
					{
						AscCharacter = Convert.ToInt32(CurrentChars);
						
					}  //end else check for 00

					if(AscCharacter < 95 && AscCharacter > 0)
					{
						AscCharacter = AscCharacter + 32;
						EncodedData = EncodedData + (char) AscCharacter;
					}  //end if checkeing for between 0 & 95
					else
					{
						if(AscCharacter > 94)
						{
							if( AscCharacter != ASCII_SPACE_CHAR )
							{
								AscCharacter = AscCharacter + 100;
							}
							EncodedData = EncodedData + (char) AscCharacter;
						} //end if checking for space character
						else
						{
							if(AscCharacter == 0)
							{
								EncodedData = EncodedData + (char) ASCII_SPACE_CHAR;
							}
						}	//end else checking for space character 
					}	//end else checking for between 0 & 95
		
					idx = idx + 1;
				}  //endif for character C check 
				else  //Not char set C...Checking for A or B 
				{ 
					//Checking for char set A
					if( ((idx <= LenDataToEncode) && (AscCharacter < 31)) || 
						( (EncodingType == enuEncodingType.EncodingA ) && (AscCharacter > 32) && 
						(AscCharacter < 96) ) )
					{
						if( EncodingType != enuEncodingType.EncodingA)
						{
							EncodedData = EncodedData + (char) ASCII_SWITCH_TO_A;
						}
						EncodingType = enuEncodingType.EncodingA;
				
						//Get the ASCII value of the next character
						ChrArray = ActualInputValue.ToCharArray(idx, 1);
						AscCharacter = (int) ChrArray[0];

						//set the CurrentValue to the number of String CurrentChar
						if(AscCharacter == 32)
						{
							EncodedData = EncodedData + (char) ASCII_SPACE_CHAR;
						}
						else
						{
							if(AscCharacter < 32)
							{
								AscCharacter = AscCharacter + 96;
								EncodedData = EncodedData + (char) AscCharacter;
							}
							else if(AscCharacter > 32)
							{
								EncodedData = EncodedData + (char) AscCharacter;
							}
						}
					}	//End check for switch to character set A
					else
					{	//Checking for Switch to character set B
						if( (idx <= LenDataToEncode) && ((AscCharacter > 31 && AscCharacter < 127) || AscCharacter == 197) )
						{
							if( EncodingType != enuEncodingType.EncodingB )
							{
								//Write switch character for Set B
								EncodedData = EncodedData + (char) ASCII_SWITCH_TO_B;
							}

							EncodingType = enuEncodingType.EncodingB;

							//Get the ASCII value of the next character
							ChrArray = ActualInputValue.ToCharArray(idx,1);
							AscCharacter = (int) ChrArray[0];
						
							if(AscCharacter == 32)
							{
								EncodedData = EncodedData + (char) ASCII_SPACE_CHAR;
							}
							else
							{
								EncodedData = EncodedData + (char) AscCharacter;
							}
						}	//End switch to B character set
					}  //end else from checking for character set A & B
				} //End Else of main If Statement
			}	//close for loop

			//Now that we have all of the characters encoded & the start & stop digits, we need to calculate
			//the check digit.

			//Calculate Modulo 103 Check Digit
			//Set WeightedTotal to the value of the start character
			WeightedTotal = ((int) OutStartCharacter) - 100;
	
			//Change the LenDataToEncode to the data that we will include in the  output.
			LenDataToEncode = EncodedData.Length;

			for(idx = 0;idx<LenDataToEncode;idx++)
			{
				//Get the ASCII value of each character
				ChrArray = EncodedData.ToCharArray(idx,1);
				AscCharacter = (int) ChrArray[0];

				//Get the Code 128 value of CurrentChar according to chart
				if( AscCharacter < 135 )
					AscCharacter = AscCharacter - 32;
				else
				{
					if( AscCharacter == 194 )
						AscCharacter = 0;
					if( AscCharacter > 134)
						AscCharacter = AscCharacter - 100;
				}
				//multiply by the weighting character
				AscCharacter = AscCharacter * (idx + 1);

				WeightedTotal = WeightedTotal + AscCharacter;

			}	//End for loop to get Weighted Total
			
			//divide the WeightedTotal by 103 and get the remainder, this is the CheckDigitValue
			iCheckDigitValue = WeightedTotal % CHECK_DIGIT_MOD;
				
			//Now that we have the CheckDigitValue, find the corresponding ASCII character from the table
			if( iCheckDigitValue < 95 && iCheckDigitValue > 0 )
			{
				iCheckDigitValue = iCheckDigitValue + 32;
			}
			else //else check digit not between 0 & 95
			{
				if( iCheckDigitValue > 94 )
				{
					iCheckDigitValue = iCheckDigitValue + 100;
				}
				else
				{
					if( iCheckDigitValue == 0 )
					{
						iCheckDigitValue = ASCII_SPACE_CHAR;
					}
				} //end if check digit > 94
			}//end if check digit between 0 & 95
			OutCheckCharacter = (char) iCheckDigitValue;
			
			EncodedData = OutStartCharacter + EncodedData + OutCheckCharacter + OutStopCharacter;
			//MessageBox.Show( EncodedData );

			return EncodedData;
		}  //End Code128()

		
		//This is a helper function that takes in a string value and determines if it is a
		//number.
		private bool IsNumber(string InNumber)
		{
			int idx = 0;
			int strLen = InNumber.Length;
			char[] InNumber2 = InNumber.ToCharArray();
			bool RtrnValue = true;
			if(strLen > 0)
			{
				for(idx=0;idx < strLen;idx++)
				{
					if(Char.IsNumber(InNumber2[idx]) == false)
						RtrnValue=false;
				}
			}
			else
			{
				RtrnValue = false;
			}
			return RtrnValue;
		} //End IsNumber function
	
		/// <summary>
		/// This method will convert data encoded for Code128 and return the human readable form
		/// of the code 
		/// </summary>
		/// <param name="InputValue">The value that is to be barcoded</param>
		/// <param name="applyTilde">Determines if tilde characters should be interpreted as escape sequence characters</param>
		/// <returns></returns>
		public string Code128HR(string InputValue, bool applyTilde)
		{
			System.Text.StringBuilder sbReturnString = new System.Text.StringBuilder();
			
			string ActualInputValue = "";	//value of input string after tilde processing
			if(applyTilde == true)
				ActualInputValue = Code128TildeProcessing(InputValue);
			else
				ActualInputValue = InputValue;

			char[] charDataToEncode = ActualInputValue.ToCharArray();
			bool FNCDone;
			for(int i = 0;i < charDataToEncode.Length;i++)
			{
				FNCDone = false;
			
				//need to make sure there are enough characters left in ActualInputValue and add AI characters
				if(i <= ActualInputValue.Length - 3 && ((int)charDataToEncode[i] == 212))
				{ //2 digit AI based on ASCII 212 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 2) + ") ");
					i += 2;
				}
				else if(i <= ActualInputValue.Length - 4 && ((int)charDataToEncode[i] == 213))
				{	//3 digit AI based on ASCII 213 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 3) + ") ");
					i += 3;
				}
				else if(i <= ActualInputValue.Length - 5 && ((int)charDataToEncode[i] == 214))
				{	//4 digit AI based on ASCII 214 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 4) + ") ");
					i += 4;
				}
				else if(i <= ActualInputValue.Length - 6 && ((int)charDataToEncode[i] == 215))
				{	//5 digit AI based on ASCII 215 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 5) + ") ");
					i += 5;
				}
				else if(i <= ActualInputValue.Length - 7 && ((int)charDataToEncode[i] == 216))
				{	//6 digit AI based on ASCII 216 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 6) + ") ");
					i += 6;
				}
				else if(i <= ActualInputValue.Length - 8 && ((int)charDataToEncode[i] == 217))
				{	//7 digit AI based on ASCII 217 being found
					sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 7) + ") ");
					i += 7;
				}
				else if(i <= ActualInputValue.Length - 4 && ((int)charDataToEncode[i] == 202) && IsNumber(ActualInputValue.Substring(i + 1, 1)) == true && IsNumber(ActualInputValue.Substring(i + 2, 1)) == true)
				{	//we can auto-detect some AIs if there is an FNC1 in the data to encode
					int Next2CharacterValue = 0;
					try
					{
						Next2CharacterValue = Convert.ToInt32(ActualInputValue.Substring(i + 1, 2));
						
						if(Next2CharacterValue == 80 || Next2CharacterValue == 81 || 
							(Next2CharacterValue <= 34 && Next2CharacterValue >= 31))
						{	//Is 4 digit AI by detection?
							sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 4) + ") ");
							i += 4;
							FNCDone = true;
						}
						if(FNCDone == false)
						{	//Is 3 digit AI by detection?
							if((Next2CharacterValue <= 49 && Next2CharacterValue >= 40) ||
								(Next2CharacterValue <= 25 && Next2CharacterValue >= 23))
							{
								sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 3) + ") ");
								i += 3;
								FNCDone = true;
							}
						}						
						if(FNCDone == false)
						{	//Is 2 digit AI by detection?
							if((Next2CharacterValue <= 30 && Next2CharacterValue >= 0) ||
								(Next2CharacterValue <= 99 && Next2CharacterValue >= 90))
							{
								sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 2) + ") ");
								i += 2;
								FNCDone = true;
							}
						}
						//If no AI was detected, set default to 4 digit AI:
						if(FNCDone == false)
						{
							sbReturnString.Append(" (" + ActualInputValue.Substring(i + 1, 4) + ") ");
							i += 4;
							FNCDone = true;
						}
					}
					catch
					{
						//took an error converting the 2 digits.  Just add the current character then
						sbReturnString.Append(ActualInputValue.Substring(i, 1));
					}					
				}
				else if(((int)charDataToEncode[i] >= 32) && ((int)charDataToEncode[i] <= 126))
				{ //everything else that is a printable ASCII charcter
					sbReturnString.Append(ActualInputValue.Substring(i, 1));
				}
				else if((int)charDataToEncode[i] < 32)
					sbReturnString.Append(" ");
			} //end for loop		
			return sbReturnString.ToString();
		}//Code128HR()
		
		//This method will create Code128 Set A encoded data from the Input string.  Code128A allows for uppercase 
		//characters, punctuation, numbers and several special functions such as a return or tab. It may be 
		//necessary to use set A to encode these functions in a barcode
		public string Code128A(string InputValue)
		{
			char Code128AStartChar;			//start character for Code 128A
			char Code128AStopChar;			//stop character for Code 128A
			char Code128ACheckDigit;		//check digit for Code 128A
			string EncodedData = "";		//This is the encoded data that we wwill return
			int idx = 0;					//for loop counter, to loop thru characters passed in
			int WeightedTotal = 0;			//used to get weighted total of characters for check digit
			int LenDataToEncode = 0;		//Len of string passed in
			char[] InputData;				//Character array of input string passed in, so that we can evaluate each charactr
			int iCurrentChar;				//Ascii value of current character
			/* Here we select character set A.  We can simply convert the ASCII value to a character
			 * by casting it as a char type */

			Code128AStartChar = (char) ASCII_START128_A;
			Code128AStopChar = (char) ASCII_STOP128;
			
			/* <<<< Calculate Modulo 103 Check Digit >>>> */
			/* Set WeightedTotal to the value of the start character */
			WeightedTotal = ASCII_START128_A - 100;

			LenDataToEncode = InputValue.Length;
			InputData = InputValue.ToCharArray();

			for(idx=0; idx < LenDataToEncode; idx++)
			{
				/* Get the ASCII value of each character */
				iCurrentChar = (int) InputData[idx];
				//cCurrentChar = InputData[idx];

				//Let's calculate the weighted total.
				if(iCurrentChar < 135)
					iCurrentChar = iCurrentChar - 32;
				else if(iCurrentChar > 134) 
					iCurrentChar = iCurrentChar - 100;
				
				//Multiply by the weighting value and add it to the total
				WeightedTotal = WeightedTotal + (iCurrentChar * (idx + 1));
			}

			/* divide the WeightedTotal by 103 and get the remainder, 
			 * this is the CheckDigitValue			*/
			
			iCurrentChar = WeightedTotal % 103;

			/* Now that we have the CheckDigitValue, find the corresponding ASCII character
			from the table */
			if(iCurrentChar < 95 && iCurrentChar > 0) 
				iCurrentChar = iCurrentChar + 32;
			else if(iCurrentChar > 94) 
				iCurrentChar = iCurrentChar + 100;
			else if(iCurrentChar == 0) 
				iCurrentChar = ASCII_SPACE_CHAR;

			//Convert the ASCII value to the character representation.
			Code128ACheckDigit = (char) iCurrentChar;


			/* Check for spaces and print ASCII 194 instead */
			/* place changes in EncodedData so that it can be returned */
			for(idx = 0;idx < LenDataToEncode;idx++)
			{
				if(InputData[idx] == ' ')
					//Check for space
					EncodedData = EncodedData + (char) ASCII_SPACE_CHAR;
				else
					EncodedData = EncodedData + InputData[idx];
			}
			EncodedData = Code128AStartChar + EncodedData + Code128ACheckDigit + Code128AStopChar;
			/* Return the EncodedData */
			return EncodedData;
		}  //End Code128A

		
		//This method will create Code128 Set B encoded data from the Input string.  Code128 B is the most common because 
		//it encodes everything from ASCII 32 to ASCII 126. It allows for upper and lower case letters, punctuation, 
		//numbers and a few select functions.
		public string Code128B(string InputValue)
		{
			char Code128BStartChar;			//start character for Code 128A
			char Code128BStopChar;			//stop character for Code 128A
			char Code128BCheckDigit;		//check digit for Code 128A
			string EncodedData = "";		//This is the encoded data that we wwill return
			int idx = 0;					//for loop counter, to loop thru characters passed in
			int WeightedTotal = 0;			//used to get weighted total of characters for check digit
			int LenDataToEncode = 0;		//Len of string passed in
			char[] InputData;				//Character array of input string passed in, so that we can evaluate each charactr
			int iCurrentChar;				//Ascii value of current character
			/* Here we select character set B.  We can simply convert the ASCII value to a character
			 * by casting it as a char type */

			Code128BStartChar = (char) ASCII_START128_B;
			Code128BStopChar = (char) ASCII_STOP128;
			
			/* <<<< Calculate Modulo 103 Check Digit >>>> */
			/* Set WeightedTotal to the value of the start character */
			WeightedTotal = ASCII_START128_B - 100;

			LenDataToEncode = InputValue.Length;
			InputData = InputValue.ToCharArray();

			for(idx=0; idx < LenDataToEncode; idx++)
			{
				/* Get the ASCII value of each character */
				iCurrentChar = (int) InputData[idx];
				//cCurrentChar = InputData[idx];

				//Let's calculate the weighted total.
				if(iCurrentChar < 135)
					iCurrentChar = iCurrentChar - 32;
				else if(iCurrentChar > 134) 
					iCurrentChar = iCurrentChar - 100;
				
				//Multiply by the weighting value and add it to the total
				WeightedTotal = WeightedTotal + (iCurrentChar * (idx + 1));
			}

			/* divide the WeightedTotal by 103 and get the remainder, 
			 * this is the CheckDigitValue			*/
			
			iCurrentChar = WeightedTotal % 103;

			/* Now that we have the CheckDigitValue, find the corresponding ASCII character
			from the table */
			if(iCurrentChar < 95 && iCurrentChar > 0) 
				iCurrentChar = iCurrentChar + 32;
			else if(iCurrentChar > 94) 
				iCurrentChar = iCurrentChar + 100;
			else if(iCurrentChar == 0) 
				iCurrentChar = ASCII_SPACE_CHAR;

			//Convert the ASCII value to the character representation.
			Code128BCheckDigit = (char) iCurrentChar;


			/* Check for spaces and print ASCII 194 instead */
			/* place changes in EncodedData so that it can be returned */
			for(idx = 0;idx < LenDataToEncode;idx++)
			{
				if(InputData[idx] == ' ')
					//Check for space
					EncodedData = EncodedData + (char) ASCII_SPACE_CHAR;
				else
					EncodedData = EncodedData + InputData[idx];

			}

			/* Return the EncodedData */
			EncodedData = Code128BStartChar + EncodedData + Code128BCheckDigit + Code128BStopChar;
			return EncodedData;
		}  //End Code128B
		
		//This routine will create a Code128 Set C encoded data string.  Set C encodes only numbers and the 
		//FNC1 function. Because the numbers are "interleaved" into pairs, two numbers are encoded into every 
		//barcode character which makes it a very high density barcode. If the number to encode is not an even 
		//number, a leading zero should be added. 
		public string Code128C(string InputValue)
		{
			char Code128CStartChar;			//start character for Code 128A
			char Code128CStopChar;			//stop character for Code 128A
			char Code128CCheckDigit;		//check digit for Code 128A
			string EncodedData = "";		//This is the encoded data that we wwill return
			int idx = 0;					//for loop counter, to loop thru characters passed in
			int WeightedTotal = 0;			//used to get weighted total of characters for check digit
			int LenDataToEncode = 0;		//Len of string passed in
			char[] InputData;				//Character array of input string passed in, so that we can evaluate each charactr
			string GoodData = "";			//This is the good data from the InputValue, once we strip out dashes
			int iCurrentChars;				//The integer value of the 2 characters we are currently working with
			string sCurrentChars;			//The sting representation of the 2 characters we are working with.
			int WeightFactor = 0;			//used to calculate the check digit
			/* Here we select character set C.  We can simply convert the ASCII value to a character
			 * by casting it as a char type */

			Code128CStartChar = (char) ASCII_START128_C;
			Code128CStopChar = (char) ASCII_STOP128;
			
			/* <<<< Calculate Modulo 103 Check Digit >>>> */
			/* Set WeightedTotal to the value of the start character */
			WeightedTotal = ASCII_START128_C - 100;

			LenDataToEncode = InputValue.Length;
			InputData = InputValue.ToCharArray();

			//First check to make sure data is number and remove and dashes
			for(idx=0; idx < LenDataToEncode; idx++)
			{
				if((Char.IsNumber(InputData[idx])) == false)
				{
					//make sure it is not a dash.  If it is a dash, remove it, otherwise get out of the function
					if(InputData[idx] != '-')
					{
//						EncodedData = "Non Numeric Data Passed In";
//						return EncodedData;
					}	//Otherwise it is a dash and we can just move on
				}
				else
				{
					GoodData = GoodData + InputData[idx];
				}
			}

			//Ensure that there is an even number of digits.  If not we need to add a zero to the end
			if((GoodData.Length % 2) != 0)
				GoodData = "0" + GoodData;

			//Calculate Mod 103 Weighted total check digit value, using only the Good Data
			LenDataToEncode = GoodData.Length;
			WeightFactor = 1;
			for(idx=0; idx < LenDataToEncode; idx = idx + 2)
			{
				/* Get the value of the current character plus the next */
				sCurrentChars = GoodData.Substring(idx,2);
				iCurrentChars = Convert.ToInt32(sCurrentChars);
				
				//Multiply by the weighting value and add it to the total
				WeightedTotal = WeightedTotal + (iCurrentChars * WeightFactor);
				WeightFactor = WeightFactor + 1;

				//Let's calculate the weighted total.
				if(iCurrentChars < 95 && iCurrentChars > 0)
					iCurrentChars = iCurrentChars + 32;
				else if(iCurrentChars > 94)
					iCurrentChars = iCurrentChars + 100;
				else if(iCurrentChars == 0) 
					iCurrentChars = ASCII_SPACE_CHAR;
				
				//Set the return value
				EncodedData = EncodedData + (char) iCurrentChars;
			}

			/* divide the WeightedTotal by 103 and get the remainder,  this is the CheckDigitValue*/			
			iCurrentChars = WeightedTotal % 103;

			/* Now that we have the CheckDigitValue, find the corresponding ASCII character
			from the table */
			if(iCurrentChars < 95 && iCurrentChars > 0) 
				iCurrentChars = iCurrentChars + 32;
			else if(iCurrentChars > 94) 
				iCurrentChars = iCurrentChars + 100;
			else if(iCurrentChars == 0) 
				iCurrentChars = ASCII_SPACE_CHAR;

			//Convert the ASCII value to the character representation.
			Code128CCheckDigit = (char) iCurrentChars;

			/* Return the EncodedData */
			EncodedData = Code128CStartChar + EncodedData + Code128CCheckDigit + Code128CStopChar;
			return EncodedData;
		} //End Code 128C

	
		//The Codabar bar code symbology is used for various numeric bar coding applications 
		//including libraries, blood banks and parcels. Codabar was designed for character 
		//self-checking eliminating the requirement for checksum characters.  However, 
		//checksum characters in the Codabar barcode are optional and they do maximize data 
		//integrity. 
		//The symbology of the Codabar character set consists of bar code symbols representing 
		//characters 0-9, Letters A to D and the following symbols: -  .  $  /  +.  Additional
		//data can be encoded in the actual choice of start and stop codes. The letters 
		//A, B C and D are used for start and stop codes. For example, if you want to print the
		//data 2727 in the Codabar barcode font you would print A2727B with the Codabar font selected. 																																																																																			   
		public string Codabar(string InputValue)
		{
			string GoodData = "";			//valid characters pulled from InputValue
			int idx = 0;					//for loop coutner
			int LenOfData = 0;				//Length of strings
			string CurrentChar = "";		//Current character we are evaluating 

			LenOfData = InputValue.Length;
			//Loop through input and remove any invalid characters.  
			/* Check to make sure data is numeric, $, +, -, /, or :, and remove all others. */
			for(idx = 0;idx < LenOfData;idx++)
			{
				CurrentChar = InputValue.Substring(idx,1);
				if( CurrentChar == "$" || CurrentChar == "+" || CurrentChar == "-" || CurrentChar == "/" || CurrentChar == ":" || IsNumber(CurrentChar) == true )
					GoodData = GoodData + CurrentChar;
			}

			return CODABAR_START_CHAR + GoodData + CODABAR_STOP_CHAR;
		}  //End Codabar function
	
		//Interleaved 2 of 5 is a numeric only barcode used for encoding pairs of numbers in a high density 
		//barcode format. Interleaved 2 of 5 barcodes always contain an even number of digits because a 
		//single Interleaved 2 of 5 barcode character represents two numbers to achieve the high density.
		//If a number containing an odd number of digits has to be encoded, a leading zero must be added 
		//to produce an even number of digits in the Interleaved 2 of 5 bar code.
		public string Interleaved2of5(string InputValue)
		{
			string GoodData = "";	//valid numeric Data from Input Value
			int LenOfData = 0;		//Length of the string we are processing
			int idx = 0;			//for loop counter
			string CurrentChar = "";//Character(s) that we are evaluating
			string OutData = "";	//This is the interleaved data which we will output
			int iCurrentChar = 0;	//The integer value of the data we are interleaving

			LenOfData = InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				CurrentChar = InputValue.Substring(idx,1);
				if(IsNumber(CurrentChar) == true)
					GoodData = GoodData + CurrentChar;
			}

			//If the length of our data is an odd number of characters, we must prepend a 0
			if((GoodData.Length % 2) != 0)
				GoodData = "0" + GoodData;

			LenOfData = GoodData.Length;
			for(idx = 0;idx < LenOfData;idx = idx + 2)
			{
				//We need to get the actual value of the 2 characters (numbers) that we would like to
				//interleave
				CurrentChar = GoodData.Substring(idx,2);
				iCurrentChar = Convert.ToInt32(CurrentChar);
				
				//Populate the string representing the encoded data
				if(iCurrentChar < 94)
					OutData = OutData + ((char) (iCurrentChar + 33));
				else
					OutData = OutData + ((char) (iCurrentChar + 103));
			}
			OutData = ( (char) ASCII_START_I2OF5 + OutData + (char) ASCII_STOP_I2OF5 );
			return OutData;
		}  //end Interleaved2of5()
	
		//This is similar to the standard Interleaved 2 of 5 method, but requires a MOD 10 check 
		//digit as part of the bar code.
		public string Interleaved2of5Mod10(string InputValue)
		{
			string GoodData = "";	//valid numeric Data from Input Value
			int LenOfData = 0;		//Length of the string we are processing
			int idx = 0;			//for loop counter
			string CurrentChar = "";//Character(s) that we are evaluating
			string OutData = "";	//This is the interleaved data which we will output
			int iCurrentChar = 0;	//The integer value of the data we are interleaving
			int WeightedTotal = 0;	//Weighted total used for check digit
			int WeightFactor = 0;	//Factor used to create weighted total
			int CheckDigit = 0;		//This is the Check sum digit

			LenOfData = InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				CurrentChar = InputValue.Substring(idx,1);
				if(IsNumber(CurrentChar) == true)
					GoodData = GoodData + CurrentChar;

			}
			//We need to come up with an even number of digits(including the check digit) so what 
			//if the value passed in has an even number of digits we have to add a zero to make it odd.
			//Once we have an odd number of digits we will add the check character to make it even again.

			if((GoodData.Length % 2) == 0)
				GoodData = "0" + GoodData;
			
			//Calculate the Check Sum character
			LenOfData = GoodData.Length;
			WeightFactor = 3;
			//We have to start ata the end and work backwards to generate the check digit
			for(idx = (LenOfData - 1);idx >= 0;idx--)
			{
				//Get the current character
				CurrentChar = GoodData.Substring(idx,1);
				iCurrentChar = Convert.ToInt32(CurrentChar);
				
				WeightedTotal = WeightedTotal + (iCurrentChar * WeightFactor);
				
				WeightFactor = 4 - WeightFactor;
			
			}
			
			//This will give us the mod 10 
			CheckDigit = WeightedTotal % 10;
			if(CheckDigit != 0)
				CheckDigit = (10 - CheckDigit);
			else
				CheckDigit = 0;
			
			//Add the ascii character representation of the check digit to the GoodData string
			GoodData = GoodData + CheckDigit.ToString();
			LenOfData = GoodData.Length;
			for(idx = 0;idx < LenOfData;idx = idx + 2)
			{
				//We need to get the actual value of the 2 characters (numbers) that we would like to
				//interleave
				CurrentChar = GoodData.Substring(idx,2);
				iCurrentChar = Convert.ToInt32(CurrentChar);
				
				//Populate the string representing the encoded data
				if(iCurrentChar < 94)
					OutData = OutData + ((char) (iCurrentChar + 33));
				else
					OutData = OutData + ((char) (iCurrentChar + 103));
			}
			OutData = ( (char) ASCII_START_I2OF5 + OutData + (char) ASCII_STOP_I2OF5 );
			return OutData;
		} //end Interleaved2of5Mod10
		
		
		//Code 39 is commonly used for various barcoding labels such as name badges, inventory 
		//and industrial applications. The Code 39 barcode is the easiest to use of alpha-numeric barcodes
		//and is designed for character self-checking, eliminating the requirement for check character 
		//calculations. 
		//The symbology of the Code 39 character set consists of bar code symbols representing 
		//characters 0-9, A-Z, the space character and the following symbols:  - , . , $ , / , + , %. 
		//In addition, the full 128 character ASCII character set can be encoded in code 39.
		public string Code39(string InputValue)
		{
			int LenOfData = 0;		//Length of the string we are processing
			string OutData = "";	//This is the interleaved data which we will output
			
			LenOfData = InputValue.Length;
			//Replace any spaces with = signs
			InputValue = InputValue.Replace(" ","=");

			OutData = "!" + InputValue + "!";

			return OutData;
		}//End Code 39

		//Code39mod43 is the same as the standard Code39, but it includes a check digit based on a mod 43 calculation
		public string Code39mod43(string InputValue)
		{
			int LenOfData = 0;		//Length of the string we are processing
			int idx = 0;			//for loop counter
			string OutData = "";	//This is the interleaved data which we will output
			int iCurrentChar = 0;	//The integer value of the data
			char[] cInputValue;		//character array of our input data
			int WeightedTotal = 0;  //Weighted Total to generate check digit
			int CheckDigit = 0;		//This is the check digit for the data

			LenOfData = InputValue.Length;
			//Convert the string to upper case
			InputValue = InputValue.ToUpper();
			cInputValue = InputValue.ToCharArray();

			//We need to loop through all characters and ensure that we are only using valid characters
			//from the input string
			for(idx=0;idx<LenOfData;idx++)
			{
				//Get the ASCII value of the current character
				iCurrentChar = (int) cInputValue[idx];
				
				if((iCurrentChar < 58) && (iCurrentChar > 47)) /* 0-9 */					
					OutData = OutData + cInputValue[idx];
				else if((iCurrentChar < 91) && (iCurrentChar > 64))  /* A-Z */
					OutData = OutData + cInputValue[idx];
				else if(iCurrentChar == 32) /* Space */
					OutData = OutData + cInputValue[idx];
				else if(iCurrentChar == 45) /* - */
					OutData = OutData + cInputValue[idx];		
				else if(iCurrentChar == 46) /* . */
					OutData = OutData + cInputValue[idx];		
				else if(iCurrentChar == 36)	/* $ */
					OutData = OutData + cInputValue[idx];	
				else if(iCurrentChar == 47) /* / */
					OutData = OutData + cInputValue[idx];	
				else if(iCurrentChar == 43) /* + */
					OutData = OutData + cInputValue[idx];	
				else if(iCurrentChar == 37)	/* % */
					OutData = OutData + cInputValue[idx];	
			}
			
			//Now get the weighted total of the characters to create the check digit
			WeightedTotal = 0;
			LenOfData = OutData.Length;
			cInputValue = OutData.ToCharArray();
			for(idx = 0;idx < LenOfData;idx++)
			{
				//Get the ASCII value of the current character
				iCurrentChar = (int) cInputValue[idx];

				/* Get the value of CurrentChar according to MOD43 standards*/				
				if((iCurrentChar<58) && (iCurrentChar>47))/* 0-9 */
					iCurrentChar = iCurrentChar-48;
				else if((iCurrentChar < 91) && (iCurrentChar > 64))	/* A-Z */
					iCurrentChar = iCurrentChar - 55;
				else if( iCurrentChar == 32 )	/* Space */
					iCurrentChar = 38;
				else if(iCurrentChar==45)/* - */
					iCurrentChar=36;
				else if(iCurrentChar == 46)	/* . */
					iCurrentChar=37;
				else if(iCurrentChar == 36) /* $ */
					iCurrentChar=39;
				else if(iCurrentChar == 47) /* / */
					iCurrentChar=40;
				else if(iCurrentChar == 43) /* + */
					iCurrentChar=41;
				else if(iCurrentChar == 37)  /* % */
					iCurrentChar=42;
				else if(iCurrentChar == 32) /* To print the barcode symbol representing a space you will to type or print "=" (the equal character) instead of a space character.*/
					iCurrentChar = 61;
				
				WeightedTotal = WeightedTotal + iCurrentChar;
			}
			CheckDigit = WeightedTotal % 43;

			//Replace any space characters with an equal sign
			OutData = OutData.Replace(" ","=");

			/* Assign values to the check digit */			
			if(CheckDigit < 10)/* 0-9 */
				CheckDigit = CheckDigit + 48;
			else if((CheckDigit < 36) && (CheckDigit > 9)) 	/* A-Z */
				CheckDigit=CheckDigit + 55;
			else if(CheckDigit==38)			/* Space */
				CheckDigit=61;
			else if(CheckDigit==36)			/* - */
				CheckDigit=45;
			else if(CheckDigit==37)		/* . */
				CheckDigit=46;
			else if(CheckDigit==39)	/* $ */
				CheckDigit=36;
			else if(CheckDigit==40)	/* / */
				CheckDigit=47;
			else if(CheckDigit==41)	/* + */
				CheckDigit=43;
			else if(CheckDigit==42)			/* % */
				CheckDigit=37;
			
			OutData = "!" + OutData + ((char) CheckDigit) + "!";
			return OutData;
		}//End Code 39 mod 43


		//The POSTNet barcode can bo one of 3 different combinations.
		//The 5 digit POSTNET bar code consists of the start/stop character, 5 digit ZIP code data, check digit 
		//and the start/stop character. The  ZIP+4 POSTNET bar code consists of the start/stop character, 
		//9 digit ZIP code data, check digit and the start/stop character. The  DPBC POSTNET bar code consists 
		//of the start/stop character, 9 digit ZIP code data, two DPBC numbers, check digit and the start/stop 
		//character.
		//The start/stop character must be used at the beginning and ending of every POSTNET barcode. 
		//For best performance, the parentheses are used for start and stop characters; "(" for start and  ")" 
		//for stop. Start and stop codes are combined for the "!, *, s, or S" characters. 
		//The last digit of the printed POSTNET barcode symbol is a check digit. The check digit is obtained by 
		//determining the number that when added to the sum of all numbers of the data in the POSTNET code will 
		//produce a multiple of 10.  
		public string POSTNet(string InputValue )
		{
			string OutData = "";		//this is the return value of the function
			string GoodData = "";		//This is the InputValue stripped of invalid characters
			int LenOfData = 0;			//Length of a string
			int idx = 0;				//for loop counter
			int WeightedTotal = 0;		//Weighted Total for check digit
			int iCurrentChar = 0;		//Integer value of current number in InputValue
			int CheckDigit = 0;			//Ascii value of check digit

			/* Check to make sure data is numeric and remove dashes, etc. */
			LenOfData = InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Add all numbers to GoodData string */
				if((IsNumber(InputValue.Substring(idx,1)))==true)
					GoodData = GoodData + InputValue.Substring(idx,1);
			}

			/* <<<< Calculate Check Digit >>>> */
			WeightedTotal=0;
			LenOfData = GoodData.Length;

			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Get the value of each number */
				iCurrentChar = Convert.ToInt32(GoodData.Substring(idx,1));
				
				/* add the values together */
				WeightedTotal = WeightedTotal + iCurrentChar;
			}

			/* Find the CheckDigit by finding the number + weightedTotal that = a multiple of 10 */
			/* divide by 10, get the remainder and subtract from 10 */
			CheckDigit = WeightedTotal % 10;
			if(CheckDigit != 0)
				CheckDigit = (10 - CheckDigit);
			else
				CheckDigit = 0;

			OutData = "(" + GoodData + (CheckDigit.ToString()) + ")";

			/* Return OutData */
			return OutData;
		} //End POSTNet


		//This is a numeric only bar code used to create European Article Numbering System (EAN) barcodes, which 
		//are a superset of U.P.C. EAN-8 consists of 8 digits for small packages. 
		public string EAN8(string InputValue)
		{
			int LenOfData = 0;			//len of string
			int idx = 0;				//for loop counter
			string OutData = "";		//this is the return value of the function
			string GoodData = "";		//This is the InputValue stripped of invalid characters
			int WeightedTotal = 0;		//Weighted Total for check digit
			int iCurrentChar = 0;		//Integer value of current number in InputValue
			int CheckDigit = 0;			//Ascii value of check digit
			int WeightFactor = 0;		//Weighted multiplier for check digit
			char[] cInputValue;			//Character array of a string

			/* Check to make sure data is numeric and remove dashes, etc. */
			LenOfData = InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Add all numbers to GoodData string */
				if((IsNumber(InputValue.Substring(idx,1)))==true)
					GoodData = GoodData + InputValue.Substring(idx,1);
			}

			if( GoodData.Length !=7)
			{
				GoodData = "Cannot process; you MUST enter a 7 digit NUMBER for this type of barcode. Do not use any spaces or dashes.";
				return GoodData;
			}

			/* <<<< Calculate Check Digit >>>> */
			WeightFactor = 3;
			WeightedTotal = 0;
			LenOfData = GoodData.Length;
			cInputValue = GoodData.ToCharArray();

			for(idx = LenOfData - 1;idx >= 0;idx--)
			{
				/* Get the value of each number */
				iCurrentChar = (int) cInputValue[idx];
				
				/* multiply by the weighting factor which is 3,1,3,1... and add the sum together */
				WeightedTotal = WeightedTotal + (iCurrentChar * WeightFactor);
				WeightFactor = 4 - WeightFactor;
			}

			/* Find the CheckDigit by finding the number + weightedTotal that = a multiple of 10 */
			/* divide by 10, get the remainder and subtract from 10 */
			CheckDigit = WeightedTotal % 10;
			if(CheckDigit != 0)
				CheckDigit = (10 - CheckDigit);
			else
				CheckDigit = 0;

			//Add the check digit to our data
			GoodData = GoodData + CheckDigit.ToString();

			/* Now that have the total number including the check digit, determine character to print for proper barcoding */
			LenOfData = GoodData.Length;
			
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Get the ASCII value of each number */
				cInputValue = GoodData.ToCharArray();
				iCurrentChar = (int) cInputValue[idx];
				switch( idx + 1 )
				{
					case 1: /* For the first character print the normal guard pattern and then the barcode without the human readable character */
						OutData = OutData + "(" + ((char) iCurrentChar);
						break;
					case 2:
						OutData = OutData + ((char) iCurrentChar);
						break;
					case 3:
						OutData = OutData + ((char) iCurrentChar);
						break;
					case 4: /* Print the center guard pattern after the 6th character */
						OutData = OutData + ((char) iCurrentChar) + "*";						
						break;
					case 5:
						OutData = OutData + ((char) (iCurrentChar+ 27));
						break;
					case 6:
						OutData = OutData + ((char) (iCurrentChar+ 27));
						break;
					case 7:
						OutData = OutData + ((char) (iCurrentChar+ 27));
						break;
					case 8: /* Print the check digit as 8th character + normal guard pattern */						
						OutData = OutData + ((char) (iCurrentChar+ 27)) + "(";
						break;
					default:
						break;
				} //End Switch
			}	//End for loop
			return OutData;
		}  //end EAN8
		
		//The European Article Numbering System (EAN) is a superset of U.P.C. EAN-13 consists of 13 numbers
		public string EAN13(string InputValue)
		{
			string OutData = "";		//this is the return value of the function
			string GoodData = "";		//This is the InputValue stripped of invalid characters
			int LenOfData = 0;			//Length of a string
			int idx = 0;				//for loop counter
			int WeightedTotal = 0;		//Weighted Total for check digit
			int WeightFactor = 0;		//The multiplier to determine the check digit.
			int iCurrentChar = 0;		//Integer value of current number in InputValue
			int CheckDigit = 0;			//Ascii value of check digit
			string EAN5AddOn = "";		//Add on characters for longer EAN symbols
			string EAN2AddOn = "";		//Add on characters for longer EAN symbols
			string Encoding = "";		//Encoding format 
			int LeadingDigit = 0;		//Ascii value of leading digit
			char[] cInputValue;			//Character array of a string
			string CurrentEncoding = "";//encoding in looop 
			string temp = "";			//Temp string 
			string EANAddOnToPrint = "";//Extended EAN information
			char EANaddchar;			//Character to add to extended EAN information
			int iEANaddchar = 0;		//integer value of above character
			char[] tempArray;			//array to hold character of strings

			/* Check to make sure data is numeric and remove dashes, etc. */
			LenOfData=InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Add all numbers to GoodData string */
				if((IsNumber(InputValue.Substring(idx,1))) == true)
					GoodData = GoodData + InputValue.Substring(idx,1);
			}

			/* DataToEncode = OnlyCorrectData */
			/* Remove check digits if they added one */
			//The value passed in will only be 12, 13, 15, or 18 digits.  The 
			LenOfData=GoodData.Length;
			if(LenOfData == 13)  //we have the 12 digit EAN plus a check digit
				GoodData = GoodData.Substring(0, 12);
			else if(LenOfData == 15) //we have the 12 digit EAN plus a check digit plus a 2 digit add on
				GoodData = GoodData.Substring(0, 12) + GoodData.Substring(13,2);
			else if(LenOfData == 18) //we have the 12 digit EAN plus a check digit plus a 5 digit add on
				GoodData = GoodData.Substring(0, 12) + GoodData.Substring(13,5);

			//Now based on the new length of Good Data we can determine what the Add on value is.
			/* End sub if incorrect number */
			if(GoodData.Length == 17)
				//Check digit has already been eliminated so this is just the EAN code and the 5 digit add on
				EAN5AddOn = GoodData.Substring(12,5);
			else if(GoodData.Length == 14)
				//Check digit has already been eliminated so this is just the EAN code and the 2 digit add on
				EAN2AddOn = GoodData.Substring(12,2);
			
			//Now set GoodData to only the EAN code (the first 12 characters
			GoodData = GoodData.Substring(0,12);

			/* ' */
			WeightFactor = 3;
			WeightedTotal = 0;

			/* <<<< Calculate Check Digit >>>> */
			/* Get the value of each number starting at the end */
			LenOfData=GoodData.Length;
			cInputValue = GoodData.ToCharArray();

			for(idx = (LenOfData - 1);idx >= 0;idx--)
			{
				/* Get the ascii value of each number starting at the end */
				iCurrentChar = ((int) cInputValue[idx]) - 48;
				/* multiply by the weighting factor which is 3,1,3,1... */
				/* and add the sum together */
				WeightedTotal = WeightedTotal + (iCurrentChar * WeightFactor);
				/* change factor for next calculation */
				WeightFactor = 4 - WeightFactor;
			}

			/* Find the CheckDigitValue by finding the number + weightedTotal that = a multiple of 10 */
			/* divide by 10, get the remainder and subtract from 10 */
			CheckDigit = WeightedTotal % 10;
			if(CheckDigit != 0)
				CheckDigit = (10 - CheckDigit);
			else
				CheckDigit = 0;

			/* Now we must encode the leading digit into the left half of the EAN-13 symbol */
			/* by using variable parity between character sets A and B */
			cInputValue = GoodData.ToCharArray();

			LeadingDigit = Convert.ToInt32(GoodData.Substring(0,1));

			switch(LeadingDigit)
			{
				case 0:
					Encoding = "AAAAAACCCCCC";
					break;
				case 1:
					Encoding = "AABABBCCCCCC";
					break;
				case 2:
					Encoding = "AABBABCCCCCC";
					break;
				case 3:
					Encoding = "AABBBACCCCCC";
					break;
				case 4:
					Encoding = "ABAABBCCCCCC";
					break;
				case 5:
					Encoding = "ABBAABCCCCCC";
					break;
				case 6:
					Encoding = "ABBBAACCCCCC";
					break;
				case 7:
					Encoding = "ABABABCCCCCC";
					break;
				case 8:
					Encoding = "ABABBACCCCCC";
					break;
				case 9:
					Encoding = "ABBABACCCCCC";
					break;
			}  //end switch addresseing encoding type

			/* add the check digit to the end of the barcode & remove the leading digit */
			GoodData = GoodData.Substring(1,11) + (CheckDigit.ToString());

			/* Now that we have the total number including the check digit, determine character to print for proper barcoding: */
			LenOfData = GoodData.Length;
			cInputValue = GoodData.ToCharArray();

			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Get the ASCII value of each number excluding the first number because it is encoded with variable parity */
				iCurrentChar = (int) cInputValue[idx];
				CurrentEncoding = Encoding.Substring(idx,1);

				/* Print different barcodes according to the location of the CurrentChar and CurrentEncoding */
				switch(CurrentEncoding)
				{
					case "A":
						OutData = OutData + cInputValue[idx];
						break;
					case "B":
						iCurrentChar = iCurrentChar + 17;
						OutData = OutData + ((char) iCurrentChar);
						break;

					case "C":
						iCurrentChar = iCurrentChar + 27;
						OutData = OutData + ((char) iCurrentChar);
						break;
					default:
						break;
				} //end switch to checking encoding type
				/* add in the 1st character along with guard patterns */
				switch(idx)
				{
					case 0:
						/* For the LeadingDigit print the human readable character, the normal guard pattern and then the rest of the barcode */
						//This is the character we will put before OutData
						if(LeadingDigit > 4)
						{
							temp = LeadingDigit.ToString();
							tempArray = temp.ToCharArray();
							iCurrentChar = ((int) tempArray[0]);
							iCurrentChar = iCurrentChar + 64;
							OutData = ((char) iCurrentChar) + "(" + OutData;
						}
						else if(LeadingDigit<5)
						{
							temp = LeadingDigit.ToString();
							tempArray = temp.ToCharArray();
							iCurrentChar = ((int) tempArray[0]);
							iCurrentChar = iCurrentChar + 37;
							OutData = ((char) iCurrentChar) + "(" + OutData;
						}						
						break;
					case 5:			/* Print the center guard pattern after the 6th character */
						OutData = OutData + "*";
						break;
					case 11:	/* For the last character (12) print the the normal guard pattern after the barcode */
						OutData = OutData + "(";
						break;
					default:
						break;
				}  //end switch for determining main output for EAN code				
			}  //end for loop that encodes the data

			/* Process 5 digit add on if it exists */
			if(EAN5AddOn.Length == 5)
			{
				/* Get check digit for add on */
				WeightFactor=3;
				WeightedTotal=0;
				for(idx = (EAN5AddOn.Length - 1); idx >= 0; idx--)
				{
					/* Get the value of each number starting at the end */
					iCurrentChar = Convert.ToInt32(EAN5AddOn.Substring(idx,1));

					/* multiply by the weighting factor which is 3,9,3,9. */
					/* and add the sum together */
					if(WeightFactor==3)
					{
						WeightedTotal = WeightedTotal + (iCurrentChar * 3);
					}
					if(WeightFactor==1)
					{
						WeightedTotal = WeightedTotal + (iCurrentChar * 9);
					}
					/* change factor for next calculation */
					WeightFactor = 4 - WeightFactor;
				}  //end check digit for loop for EAN 5 character add on

				/* Find the CheckDigit by extracting the right-most number from weightedTotal */
				temp = WeightedTotal.ToString();
				CheckDigit = Convert.ToInt32(temp.Substring(temp.Length - 1,1));

				/* Now we must encode the add-on CheckDigit into the number sets */
				/* by using variable parity between character sets A and B */
				switch(CheckDigit)
				{
					case 0:
						Encoding = "BBAAA";
						break;
					case 1:
						Encoding = "BABAA";
						break;
					case 2:
						Encoding = "BAABA";
						break;
					case 3:
						Encoding = "BAAAB";
						break;
					case 4:
						Encoding = "ABBAA";
						break;
					case 5:
						Encoding = "AABBA";
						break;
					case 6:
						Encoding = "AAABB";
						break;
					case 7:
						Encoding = "ABABA";
						break;
					case 8:
						Encoding = "ABAAB";
						break;
					case 9:
						Encoding = "AABAB";
						break;
				} //end switch for EAN 5 encoding type

				/* Now that we have the total number including the check digit, determine character to print for proper barcoding: */
				LenOfData = EAN5AddOn.Length;
				EANAddOnToPrint = "";
				for(idx = 0;idx < LenOfData;idx++)
				{
					/* Get the value of each number it is encoded with variable parity */
					iCurrentChar = Convert.ToInt32(EAN5AddOn.Substring(idx,1));
					CurrentEncoding = Encoding.Substring(idx,1);
					
					if(CurrentEncoding == "A") /* Print different barcodes according to the location of the CurrentChar and CurrentEncoding */
					{
						switch (iCurrentChar)
						{
							case 0:
								iEANaddchar = 34;
								break;
							case 1:
								iEANaddchar = 35;
								break;
							case 2:
								iEANaddchar = 36;
								break;
							case 3:
								iEANaddchar = 37;
								break;
							case 4:
								iEANaddchar = 38;
								break;
							case 5:
								iEANaddchar = 44;
								break;
							case 6:
								iEANaddchar = 46;
								break;
							case 7:
								iEANaddchar = 47;
								break;
							case 8:
								iEANaddchar = 58;
								break;
							case 9:
								iEANaddchar = 59;
								break;
							
						} //end character switch for EAN 5 character for encoding A
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
					} //End if Encoding A for EAN 5 character add on
					else if(CurrentEncoding == "B")
					{
						switch (iCurrentChar)
						{
							case 0:
								iEANaddchar = 122;
								break;
							case 1:
								iEANaddchar = 61;
								break;
							case 2:
								iEANaddchar = 63;
								break;
							case 3:
								iEANaddchar = 64;
								break;
							case 4:
								iEANaddchar = 91;
								break;
							case 5:
								iEANaddchar = 92;
								break;
							case 6:
								iEANaddchar = 93;
								break;
							case 7:
								iEANaddchar = 95;
								break;
							case 8:
								iEANaddchar = 123;
								break;
							case 9:
								iEANaddchar = 125;
								break;
							
						}//End switch for EAN5 add on w/ B encoding
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
					} //end else for Encoding B for EAN add on 5 characters
					
					switch (idx)/* add in the space & add-on guard pattern */
					{
						case 0:
							iEANaddchar = 43;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANaddchar + EANAddOnToPrint;
							iEANaddchar = 32;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANaddchar + EANAddOnToPrint;
							iEANaddchar = 33;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
							break;
						case 1:
							iEANaddchar = 33;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
							break;
						case 2:
							iEANaddchar = 33;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
							break;
						case 3:
							iEANaddchar = 33;
							EANaddchar = (char) iEANaddchar;
							EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
							break;
						case 4:
							//do nothing
							break;
					}  //end add character switch
				} //end for loop to determine encoding characters
			} //end EAN length = 5

			/* Process 2 digit add on if it exists */
			if(EAN2AddOn.Length == 2)
			{
				//Get the actual value of the EAN2 add on
				iEANaddchar = Convert.ToInt32(EAN2AddOn);
				
				/* Get encoding for add on */
				for(idx = 0;idx <= 99;idx = idx + 4)
				{
					if(iEANaddchar == idx)
						Encoding = "AA";
					else if(iEANaddchar == (idx + 1))
						Encoding = "AB";
					else if(iEANaddchar == (idx + 2))
						Encoding = "BA";
					else if(iEANaddchar == (idx + 3))
						Encoding = "BB";	
				} //end for loop determining encoding type
				
				LenOfData = EAN2AddOn.Length;  /* Now that we have the total number including the encoding determine what to print */
				for(idx = 0;idx < LenOfData;idx++)
				{
					/* Get the value of each number it is encoded with variable parity */
					iCurrentChar = Convert.ToInt32(EAN2AddOn.Substring(idx,1));
					CurrentEncoding = Encoding.Substring(idx,1);

					/* Print different barcodes according to the location of the CurrentChar and CurrentEncoding */
					if(CurrentEncoding == "A")
					{
						switch (iCurrentChar)
						{
							case 0:
								iEANaddchar = 34;
								break;
							case 1:
								iEANaddchar = 35;
								break;
							case 2:
								iEANaddchar = 36;
								break;
							case 3:
								iEANaddchar = 37;
								break;
							case 4:
								iEANaddchar = 38;
								break;
							case 5:
								iEANaddchar = 44;
								break;
							case 6:
								iEANaddchar = 46;
								break;
							case 7:
								iEANaddchar = 47;
								break;
							case 8:
								iEANaddchar = 58;
								break;
							case 9:
								iEANaddchar = 59;
								break;
						}  //end switch encoding A
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
					}//End if Encoding A
					else if(CurrentEncoding == "B")
					{
						switch (iCurrentChar)
						{
							case 0:
								iEANaddchar = 122;
								break;
							case 1:
								iEANaddchar = 61;
								break;
							case 2:
								iEANaddchar = 63;
								break;
							case 3:
								iEANaddchar = 64;
								break;
							case 4:
								iEANaddchar = 91;
								break;
							case 5:
								iEANaddchar = 92;
								break;
							case 6:
								iEANaddchar = 93;
								break;
							case 7:
								iEANaddchar = 95;
								break;
							case 8:
								iEANaddchar = 123;
								break;
							case 9:
								iEANaddchar = 125;
								break;							
						} //end switch encoding B
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
					}  //end else if for encoding B
					/* add in the space & add-on guard pattern */
					if(idx == 0)
					{
						iEANaddchar = 43;
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANaddchar + EANAddOnToPrint;
						
						iEANaddchar = 33;
						EANaddchar = (char) iEANaddchar;
						EANAddOnToPrint = EANAddOnToPrint + EANaddchar;
					}  //end if idx ==1
					
				}//End for loop through characters for EAN Add of length 2
			} //End if EANAdd On Length is 2


			/* Get OutData String */
			OutData = OutData + EANAddOnToPrint;
			/* Return OutData */
			return OutData;
		}//End EAN13


		//The symbology of the MSI Plessey character set consists of bar code symbols representing the numbers 
		//0-9, the start character and the stop character. In the MSI Plessey font, the parentheses are used 
		//for start and stop characters.  A check digit character is included with this encoding before the 
		//closing parentheses.
		public string MSI(string InputValue)
		{
			string OutData = "";		//this is the return value of the function
			string GoodData = "";		//This is the InputValue stripped of invalid characters
			int LenOfData = 0;			//Length of a string
			int idx = 0;				//for loop counter
			int WeightedTotal = 0;		//Weighted Total for check digit
			int CheckDigit = 0;			//Ascii value of check digit
			string OddNumbers = "";		//string of odd numbers from input value
			int iOddNumbers = 0;		//integr of the OddNumbers string
			int EvenNumbers = 0;		//sum of all even numbers in input value

			/* Check to make sure data is numeric and remove dashes, etc. */
			LenOfData=InputValue.Length;

			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Add all numbers to OnlyCorrectData string */
				if((IsNumber(InputValue.Substring(idx,1))) == true)
					GoodData = GoodData + InputValue.Substring(idx,1);
			}

			/* <<<< Calculate Check Digit >>>> */
			WeightedTotal = 0;
			LenOfData=GoodData.Length;
			
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Get the value of each EVEN number, 1st number is even & add them together */
				if(((idx + 1) % 2) == 1 )  //means this is odd
					OddNumbers = OddNumbers + GoodData.Substring(idx,1);
				else if(((idx + 1) % 2) == 0) //means it's even
					EvenNumbers = EvenNumbers + Convert.ToInt32(GoodData.Substring(idx,1));
			}

			/* Multiply odd numbers gathered by 2 */
			iOddNumbers = (Convert.ToInt32(OddNumbers)) * 2;

			//turn it back into a string
			OddNumbers = iOddNumbers.ToString();

			/* Add the digits of the product together */
			LenOfData = OddNumbers.Length;
			iOddNumbers = 0;
			for(idx = 0;idx < LenOfData;idx++)
			{
				iOddNumbers = iOddNumbers + Convert.ToInt32(OddNumbers.Substring(idx,1));
			}

			WeightedTotal=iOddNumbers + EvenNumbers;

			/* Find the CheckDigit by finding the number + weightedTotal that = a multiple of 10 */
			/* divide by 10, get the remainder and subtract from 10 */
			iOddNumbers = WeightedTotal % 10;
			if(iOddNumbers !=0)
				CheckDigit = (10 - iOddNumbers);
			else
				CheckDigit = 0;
					

			/* Get OutData String */
			OutData = "(" + OutData + GoodData + (CheckDigit.ToString()) + ")";
			/* Return OutData */
			return OutData;
		}//End MSI 

		//This will create the encoding necessary to generate a UPCA bar code.
		//The UPCA code is always 11 digits + a check character + an optional 2 or 5
		//digit add on number combination.
		public string UPCA(string InputValue)
		{
			int idx = 0;				//for loop counter
			int LenOfData;				//length of a string
			string GoodData = "";		//Invalid characters stripped from InputValue
			char[] cData;				//character array representation of a string to check ascii values of characters
			string EAN5AddOn = "";		//5 digit EAN Add On code
			string EAN2AddOn = "";		//2 digit EAN Add On code
			int WeightFactor = 0;		//Weighting multiplier for calculating check digit
			int WeightedTotal = 0;		//Weighted Total for creating check digit
			int CheckDigit = 0;			//This is the check digit for our upc code
			int iCurrentChar = 0;		//ASCII value of current character.
			int iCharNumber = 0;		//actual value of a numeric character string
			string DataToPrint = "";	//This is the actual encoded data once we have formatted the Input Value. This will be the function return value
			string Encoding = "";		//This is the encoding method that we are going to use for the EAN Add ons
			string sTemp = "";			//Temporary string for data manipulation
			string CurrEncoding = "";	//Encoding method for particular character
			string EANAddOnToPrint = "";//This is the encoded EAN add on that we will add to our DataToPrint output string
			int EANToPrintAscii = 0;	//This is the ascii character that is the encoded representation of a character in EAN add on

			cData = InputValue.ToCharArray();
			LenOfData = InputValue.Length;
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Add all numbers to GoodData string */
				if(Char.IsNumber(cData[idx]) == true)
					GoodData = GoodData + cData[idx];
			}	//end loop for checking characters

			/* Remove check digits if they added one and retrieve the add on digits, if any. */
			//In order for this to be a valid code the length of the data can be only one of
			//3 values:  12, 14, 17.  This represents an 11 digit UPCA code, a check digit, 
			//and the options 2 or 5 digit add on code.  We strip off all check digits and 
			//recalculate it later, just to make sure it is accurate.
			switch(GoodData.Length)
			{
				case 12:		//11 digit upc code + check digit
					GoodData = GoodData.Substring(0, 11);
					break;
				case 14:		//11 digit upc code + check digit + 2 digit add on
					EAN2AddOn = GoodData.Substring(12);
					GoodData = GoodData.Substring(0, 11);
					break;
				case 17:		//11 digit upc code + check digit + 5 digit add on
					EAN5AddOn = GoodData.Substring(12);
					GoodData = GoodData.Substring(0, 11);
					break;
			}  //end switch for getting UPC code and Add On data
			
			/* <<<< Calculate Check Digit and add it to the end of the GoodData string for 
			 * bar code generation>>>> */
			WeightFactor = 3;
			WeightedTotal = 0;
			LenOfData = GoodData.Length;
			
			for(idx = (LenOfData - 1);idx >= 0;idx--)
			{
				/* Get the value of each character string starting at the end */
				iCharNumber = Convert.ToInt32(GoodData.Substring(idx,1));

				/* multiply by the weighting factor which is 3,1,3,1... */
				/* and add the sum together */
				WeightedTotal = WeightedTotal + (iCharNumber * WeightFactor);
				
				/* change factor for next calculation */
				WeightFactor = 4 - WeightFactor;
			}	//end loop creating Weighted Total for Check digit

			/* Find the CheckDigit by finding the number + weightedTotal that = a multiple of 10 */
			/* divide by 10, get the remainder and subtract from 10 */
			CheckDigit = WeightedTotal % 10;
			if(CheckDigit !=0)
				CheckDigit = 10 - CheckDigit;
			else
				CheckDigit = 0;
			
			//Add the check digit to our GoodData string representing our actual bar code data
			GoodData = GoodData + CheckDigit.ToString();

			/* Now that have the total number including the check digit, determine the actual characters
			 * to print for proper barcoding */
			LenOfData = GoodData.Length;
			cData = GoodData.ToCharArray();
			DataToPrint = "";		//initialize our return value
			for(idx = 0;idx < LenOfData;idx++)
			{
				/* Get the ASCII value of each number */
				iCurrentChar = (int) cData[idx];
				/* Get the actual value of each string value */
				iCharNumber = Convert.ToInt32(GoodData.Substring(idx,1));
				
				/* Print different barcodes according to the location of the CurrentChar (idx value) */
				switch (idx)
				{
					case 0:
						/* For the first character print the human readable character, the normal  */
						/* guard pattern and then the barcode without the human readable character */
						/* First get the actual value of the character to determine what to add to */
						/* the ASCII value */
						if(iCharNumber > 4)
							DataToPrint = ((char) (iCurrentChar + 64)) + "(" + ((char) (iCurrentChar + 49));
						else if(iCharNumber<5)
							DataToPrint = ((char) (iCurrentChar + 37)) + "(" + ((char) (iCurrentChar + 49));
						break;
					case 5:
						DataToPrint = DataToPrint + cData[idx] + "*";
						break;
					case 11:
						/* For the last character print the barcode without the human readable character, */
						/* the normal guard pattern and then the human readable character. */
						DataToPrint = DataToPrint + ((char) (iCurrentChar + 59)) + "(";
						if(iCharNumber > 4)
							DataToPrint = DataToPrint + ((char) (iCurrentChar + 64));
						else if(iCharNumber<5)
							DataToPrint = DataToPrint + ((char) (iCurrentChar + 37));
						break;
					default:  //for 2,3,4,5
						if(idx > 0 && idx < 5)
							DataToPrint = DataToPrint + cData[idx];
						else if(idx > 5 && idx < 11)
							/* Add 27 to the ASII value of characters 6-12 to print from character set+ C */
							/* this is required when printing to the right of the center guard pattern */
							DataToPrint = DataToPrint + ((char) (iCurrentChar + 27));
						break;
				} //End switch statement for encoding characters into output string 
			}	//End for loop going through characters to determine encoding.

			//Process the 5 digit EAN add on, if it exists
			if(EAN5AddOn.Length == 5)
			{
				/* Get check digit for add on */
				WeightFactor = 3;
				WeightedTotal = 0;
				LenOfData = EAN5AddOn.Length;
				
				for(idx = (LenOfData - 1);idx >= 0;idx--)
				{
					/* Get the value of each character string starting at the end */
					iCharNumber = Convert.ToInt32(EAN5AddOn.Substring(idx,1));

					/* multiply by the weighting factor which is 3,1,3,1... */
					/* and add the sum together */
					if(WeightFactor == 3)
						WeightedTotal = WeightedTotal + (iCharNumber * 3);
					else if(WeightFactor == 1)
						WeightedTotal = WeightedTotal + (iCharNumber * 9);
					/* change factor for next calculation */
					WeightFactor = 4 - WeightFactor;
				}	//end loop creating Weighted Total for Check digit

				
				/* Find the CheckDigit by extracting the right-most number ( the value of the 
				 * last character from weightedTotal */
				sTemp = WeightedTotal.ToString();
				CheckDigit = Convert.ToInt32(sTemp.Substring(sTemp.Length-1)); //-1 because substring is 0-based

				/* Now we must encode the add-on CheckDigit into the number sets */
				/* by using variable parity between character sets A and B */
				switch(CheckDigit)
				{
					case 0:
						Encoding = "BBAAA";
						break;
					case 1:
						Encoding = "BABAA";
						break;
					case 2:
						Encoding = "BAABA";
						break;
					case 3:
						Encoding = "BAAAB";
						break;
					case 4:
						Encoding = "ABBAA";
						break;
					case 5:
						Encoding = "AABBA";
						break;
					case 6:
						Encoding = "AAABB";
						break;
					case 7:
						Encoding = "ABABA";
						break;
					case 8:
						Encoding = "ABAAB";
						break;
					case 9:
						Encoding = "AABAB";
						break;
				}	//end switch to dtermine encoding

				/* Now that we have the total number including the check digit, determine character to print for proper barcoding: */
				LenOfData = EAN5AddOn.Length;
				
				for(idx = 0;idx < LenOfData;idx++)
				{					
					iCharNumber = Convert.ToInt32(EAN5AddOn.Substring(idx,1));/* Get the actual value of each number.  Note that it is encoded with variable parity */
					CurrEncoding = Encoding.Substring(idx,1);					
					if(CurrEncoding == "A")
					{
						switch(iCharNumber)
						{
							case 0:
								EANToPrintAscii = 34;
								break;
							case 1:
								EANToPrintAscii = 35;
								break;
							case 2:
								EANToPrintAscii = 36;
								break;
							case 3:
								EANToPrintAscii = 37;
								break;
							case 4:
								EANToPrintAscii = 38;
								break;
							case 5:
								EANToPrintAscii = 44;
								break;
							case 6:
								EANToPrintAscii = 46;
								break;
							case 7:
								EANToPrintAscii = 47;
								break;
							case 8:
								EANToPrintAscii = 58;
								break;
							case 9:
								EANToPrintAscii = 59;
								break;
						} //end switch charNumber for encoding A
					}	//end if Curr Encoding == A
					else if(CurrEncoding == "B")
					{
						switch(iCharNumber)
						{
							case 0:
								EANToPrintAscii = 122;
								break;
							case 1:
								EANToPrintAscii = 61;
								break;
							case 2:
								EANToPrintAscii = 63;
								break;
							case 3:
								EANToPrintAscii = 64;
								break;
							case 4:
								EANToPrintAscii = 91;
								break;
							case 5:
								EANToPrintAscii = 92;
								break;
							case 6:
								EANToPrintAscii = 93;
								break;
							case 7:
								EANToPrintAscii = 95;
								break;
							case 8:
								EANToPrintAscii = 123;
								break;
							case 9:
								EANToPrintAscii = 125;
								break;
						} //end switch charNumber for encoding A
					}	//end else if CurrEncoding == B
					EANAddOnToPrint = EANAddOnToPrint + ((char) EANToPrintAscii);					
					switch(idx)/* add in the space & add-on guard pattern */
					{
						case 0: /* and Now print add-on delineators between each add-on character */
							iCharNumber = 43;
							EANAddOnToPrint = ((char) iCharNumber) + EANAddOnToPrint;
							iCharNumber = 33;
							EANAddOnToPrint = EANAddOnToPrint + ((char) iCharNumber);
							break;
						case 1:
							iCharNumber = 33;
							EANAddOnToPrint = EANAddOnToPrint + ((char) iCharNumber);
							break;
						case 2:
							iCharNumber = 33;
							EANAddOnToPrint = EANAddOnToPrint + ((char) iCharNumber);
							break;
						case 3:
							iCharNumber = 33;
							EANAddOnToPrint = EANAddOnToPrint + ((char) iCharNumber);
							break;
						default:
							break;
					}	//End switch for creating EANAddOnToPrint
				}	//End for loop through EAN 5 digit Add on
			}	//End if check for existance of 5 digit add on
			
			//Now check and see if we have a 2 digit add on
			/* Process 2 digit add on if it exists */
			if(EAN2AddOn.Length == 2)
			{
				iCharNumber = Convert.ToInt32(EAN2AddOn);
				for(idx = 0;idx <= 99;idx = idx + 4)
				{
					if(iCharNumber == idx)
						Encoding = "AA";
					else if(iCharNumber == idx + 1)
						Encoding = "AB";
					else if(iCharNumber == idx + 2)
						Encoding = "BA";
					else if(iCharNumber == idx + 3)
						Encoding = "BB";
				}// end for loop determinging encoding type
				
				LenOfData = EAN2AddOn.Length; /* Now that we have the total number including the encoding determine what to print */
				for(idx = 0;idx < LenOfData;idx++)
				{
					/* Get the actual value of each number.  note that it is encoded with variable parity */
					iCharNumber = Convert.ToInt32(EAN2AddOn.Substring(idx,1));
					CurrEncoding = Encoding.Substring(idx,1);					
					if(CurrEncoding == "A")
					{
						switch(iCharNumber)
						{
							case 0:
								EANToPrintAscii = 34;
								break;
							case 1:
								EANToPrintAscii = 35;
								break;
							case 2:
								EANToPrintAscii = 36;
								break;
							case 3:
								EANToPrintAscii = 37;
								break;
							case 4:
								EANToPrintAscii = 38;
								break;
							case 5:
								EANToPrintAscii = 44;
								break;
							case 6:
								EANToPrintAscii = 46;
								break;
							case 7:
								EANToPrintAscii = 47;
								break;
							case 8:
								EANToPrintAscii = 58;
								break;
							case 9:
								EANToPrintAscii = 59;
								break;
						} //end switch charNumber for encoding A
					}	//end if Curr Encoding == A
					else if(CurrEncoding == "B")
					{
						switch(iCharNumber)
						{
							case 0:
								EANToPrintAscii = 122;
								break;
							case 1:
								EANToPrintAscii = 61;
								break;
							case 2:
								EANToPrintAscii = 63;
								break;
							case 3:
								EANToPrintAscii = 64;
								break;
							case 4:
								EANToPrintAscii = 91;
								break;
							case 5:
								EANToPrintAscii = 92;
								break;
							case 6:
								EANToPrintAscii = 93;
								break;
							case 7:
								EANToPrintAscii = 95;
								break;
							case 8:
								EANToPrintAscii = 123;
								break;
							case 9:
								EANToPrintAscii = 125;
								break;
						} //end switch charNumber for encoding A
					}	//end else if CurrEncoding == B
					EANAddOnToPrint = EANAddOnToPrint + ((char) EANToPrintAscii);

					if(idx == 0)/* add in the space & add-on guard pattern */
					{
						iCharNumber = 43;
						EANAddOnToPrint = ((char) iCharNumber) + EANAddOnToPrint;
						iCharNumber = 33;
						EANAddOnToPrint = EANAddOnToPrint + ((char) iCharNumber);
					}	//End if 
				}//end for loop through 2 digit characters
			} //End check for 2 digit add on
			DataToPrint = DataToPrint + EANAddOnToPrint;
			return DataToPrint;
		} //end UPCA method

		public string UPCe(string InputValue)
		{
			System.Text.StringBuilder sbOutput = new System.Text.StringBuilder();
			System.Text.StringBuilder EANAddOnToPrint = new System.Text.StringBuilder();
			string ActualInputValue = "";  //This is the input value after it has been cut & cleaned
			string EAN2AddOn = "";	//optional 2 digit add on
			string EAN5AddOn = "";	//optional 5 digit add on
			int StringLength = InputValue.Length;
			
			for(int idx = 0;idx < InputValue.Length;idx++)
			{
				//we are only going to allow, at most, 18 characters to be procesed
				if(ActualInputValue.Length == 18)
					break;
				else if(Char.IsDigit(InputValue, idx) == true) //Make sure we only have numbers
					ActualInputValue += InputValue.Substring(idx, 1);
			}

			//If the user passed in bad data or invalid length, we will return a standard value
			if(ActualInputValue.Length < 11 || ActualInputValue.Length == 15 || ActualInputValue.Length > 18)
				ActualInputValue = "00005000000";
	
			//remove check digits so we can recalculate and pull off supplements
			if(ActualInputValue.Length == 12)
				ActualInputValue = ActualInputValue.Substring(0, 11);
			else if(ActualInputValue.Length == 13)
			{
				ActualInputValue = ActualInputValue.Substring(0, 11);
				EAN2AddOn = ActualInputValue.Substring(12, 2);
			}
			else if(ActualInputValue.Length == 14)
			{
				ActualInputValue = ActualInputValue.Substring(0, 11);
				EAN2AddOn = ActualInputValue.Substring(13, 2);
			}
			else if(ActualInputValue.Length == 16)
			{
				ActualInputValue = ActualInputValue.Substring(0, 11);
				EAN5AddOn = ActualInputValue.Substring(11, 5);
			}
			else if(ActualInputValue.Length == 17)
			{
				ActualInputValue = ActualInputValue.Substring(0, 11);
				EAN5AddOn = ActualInputValue.Substring(13, 5);
			}
			
			//Calculate the check digit
			int Factor = 3;
			int WeightedTotal = 0;
	 
			//we need to go backwards thru OnlyCorrectData for the check digit
			for(int I = ActualInputValue.Length - 1;I >= 0;I--)
			{
				//Get the value of each number starting at the end
				int CurrentNumber = Convert.ToInt32(ActualInputValue.Substring(I, 1));
				WeightedTotal = WeightedTotal + (CurrentNumber * Factor);
				Factor = 4 - Factor;  //change factor for next calculation
			}
			
			//Find the CheckDigit by finding the number + WeightedTotal that = a multiple of 10
			//divide by 10, get the remainder and subtract from 10
			int remainder = (WeightedTotal % 10);
			int CheckDigit = 0;
			if(remainder != 0)
			{
				remainder = 10 - remainder;
				ActualInputValue += remainder.ToString();
			}
			else
				ActualInputValue += "0";

			//Compress UPC-A to UPC-E if possible
			int D1 = Convert.ToInt32(ActualInputValue.Substring(0, 1));
			int D2 = Convert.ToInt32(ActualInputValue.Substring(1, 1));
			int D3 = Convert.ToInt32(ActualInputValue.Substring(2, 1));
			int D4 = Convert.ToInt32(ActualInputValue.Substring(3, 1));
			int D5 = Convert.ToInt32(ActualInputValue.Substring(4, 1));
			int D6 = Convert.ToInt32(ActualInputValue.Substring(5, 1));
			int D7 = Convert.ToInt32(ActualInputValue.Substring(6, 1));
			int D8 = Convert.ToInt32(ActualInputValue.Substring(7, 1));
			int D9 = Convert.ToInt32(ActualInputValue.Substring(8, 1));
			int D10 = Convert.ToInt32(ActualInputValue.Substring(9, 1));
			int D11 = Convert.ToInt32(ActualInputValue.Substring(10, 1));
			int D12 = Convert.ToInt32(ActualInputValue.Substring(11, 1));

			//Condition A
			if((D11 == 5 || D11 == 6 || D11 == 7 || D11 == 8 || D11 == 9) && (D6 != 0 && D7 == 0 && D8 == 0 && D9 == 0 && D10 == 0))
				ActualInputValue = string.Format("{0}{1}{2}{3}{4}{5}", D2, D3, D4, D5, D6, D11);
			else if((D6 == 0 && D7 == 0 && D8 == 0 && D9 == 0 && D10 == 0) && D5 != 0)  //Condition B
				ActualInputValue = string.Format("{0}{1}{2}{3}{4}{5}", D2, D3, D4, D5, D11, "4");
			/*Condition C*/	
			else if((D5 == 0 && D6 == 0 && D7 == 0 && D8 == 0)&& (D4 == 1 || D4 == 2 || D4 == 0))
				ActualInputValue = string.Format("{0}{1}{2}{3}{4}{5}", D2, D3, D9, D10, D11, D4);
			/*Condition D*/	
			else if((D5 == 0 && D6 == 0 && D7 == 0 && D8 == 0 && D9 == 0) && (D4 >= 3 && D4 <= 9))
				ActualInputValue = string.Format("{0}{1}{2}{3}{4}{5}", D2, D3, D4, D10, D11, "3");
			else
				ActualInputValue = ActualInputValue;

			//Run UPC-E compression only if DataToEncode = 6
			if(ActualInputValue.Length == 6)
			{
				//Now we must encode the check character into the symbol
				//by using variable parity between character sets A and B
				string Encoding = "";
				switch(D12)
				{
					case 0:
						Encoding = "BBBAAA";
						break;
					case 1:
						Encoding = "BBABAA";
						break;
					case 2:
						Encoding = "BBAABA";
						break;
					case 3:
						Encoding = "BBAAAB";
						break;
					case 4:
						Encoding = "BABBAA";
						break;
					case 5:
						Encoding = "BAABBA";
						break;
					case 6:
						Encoding = "BAAABB";
						break;
					case 7:
						Encoding = "BABABA";
						break;
					case 8:
						Encoding = "BABAAB";
						break;
					case 9:
						Encoding = "BAABAB";
						break;
				}
				for(int I = 1;I <= ActualInputValue.Length;I++)
				{
					if(I == 1)
					{
						//For the LeadingDigit print the human readable character, the normal guard pattern and then the rest of the barcode
						//This is the first character so we restart the buffer from the begining
						sbOutput.Append((char)85);
						sbOutput.Append("(");
					}
					//Get the ASCII value of each number
					int CurrentNumber = ActualInputValue.ToCharArray()[I - 1];

					//Print different barcodes according to the location of the CurrentChar and CurrentEncoding
					switch(Encoding.ToCharArray()[I - 1])
					{
						case 'A':
							sbOutput.Append((char)CurrentNumber);
							break;
						case 'B':
							sbOutput.Append((char)(CurrentNumber + 17));
							break;
					}

					//add in the 1st character along with guard patterns
					switch(I)
					{				
						case 1:					
							break;
						case 6: //Print the SPECIAL guard pattern and check character		
							sbOutput.Append(")");
							if(D12 > 4)
								sbOutput.Append((char)((int)(D12.ToString().ToCharArray()[0]) + 64));
							if(D12 < 5)
								sbOutput.Append((char)((int)(D12.ToString().ToCharArray()[0]) + 37));
							break;
					}//end switch
				}//end for loop 
			} // end if length is 6
			
			//if we weren't able to compress DataToEncode into 6 characters....determine character to print for proper upc-a barcoding
			if(ActualInputValue.Length != 6)
			{
				for(int I = 1;I <= ActualInputValue.Length;I++)
				{
					//Get the ASCII value of each number
					int CurrentNumber = ActualInputValue.ToCharArray()[I - 1];

					//Print different barcodes according to the location of the CurrentChar
					switch(I)
					{
						case 1:
							//For the first character print the human readable character, the normal
							//guard pattern and then the barcode without the human readable character
							if(Convert.ToInt32(ActualInputValue.Substring(I - 1, 1)) > 4)
								sbOutput.Append((char)(CurrentNumber + 64));
							else
								sbOutput.Append((char)(CurrentNumber + 37));
							sbOutput.Append("(");
							sbOutput.Append((char)(CurrentNumber + 49));
							break;
						case 2:
							sbOutput.Append(ActualInputValue.Substring(I - 1, 1));
							break;
						case 3:
							sbOutput.Append(ActualInputValue.Substring(I - 1, 1));
							break;
						case 4:
							sbOutput.Append(ActualInputValue.Substring(I - 1, 1));
							break;
						case 5:
							sbOutput.Append(ActualInputValue.Substring(I - 1, 1));
							break;
						case 6:
							//Print the center guard pattern after the 6th character
							sbOutput.Append(ActualInputValue.Substring(I - 1, 1));
							sbOutput.Append("*");
							break;
						case 7:
							//Add 27 to the ASII value of characters 6-12 to print from character set+ C
							//this is required when printing to the right of the center guard pattern
							sbOutput.Append((char)(CurrentNumber + 27));
							break;
						case 8:
							sbOutput.Append((char)(CurrentNumber + 27));
							break;
						case 9:
							sbOutput.Append((char)(CurrentNumber + 27));
							break;
						case 10:
							sbOutput.Append((char)(CurrentNumber + 27));
							break;
						case 11:
							sbOutput.Append((char)(CurrentNumber + 27));
							break;
						case 12:
							//For the last character print the barcode without the human readable character,
							//the normal guard pattern and then the human readable character.
							sbOutput.Append((char)(CurrentNumber + 59));
							sbOutput.Append(")");
							if(Convert.ToInt32(ActualInputValue.Substring(I - 1, 1)) > 4)
								sbOutput.Append((char)(CurrentNumber + 64));
							else
								sbOutput.Append((char)(CurrentNumber + 37));
							break;
					}//end switch
				}//end for loop thru characters
			} //end if not 6 characters

			//Process 5 digit add on if it exists
			if(EAN5AddOn.Length == 5)
			{
				//Get check digit for add on
				Factor = 3;
				WeightedTotal = 0;
				for(int I = EAN5AddOn.Length - 1;I >= 0;I--)
				{
					//Get the value of each number starting at the end
					int CurrentNumber = Convert.ToInt32(EAN5AddOn.Substring(I, 1));
					//multiply by the weighting factor which is 3,9,3,9...and add the sum together
					if(Factor == 3)
						WeightedTotal = WeightedTotal + (CurrentNumber * 3);
					if(Factor == 1 )
						WeightedTotal = WeightedTotal + (CurrentNumber * 9);
        
					//change factor for next calculation
					Factor = 4 - Factor;
				} //end loop thru characters
				//Find the CheckDigit by extracting the right-most number from WeightedTotal
				string sCheck = WeightedTotal.ToString();
				CheckDigit = Convert.ToInt32(sCheck.Substring(sCheck.Length - 1, 1));
				string Encoding = "";
				//Now we must encode the add-on CheckDigit into the number sets
				//by using variable parity between character sets A and B
				switch(CheckDigit)
				{
					case 0:
						Encoding = "BBAAA";
						break;
					case 1:
						Encoding = "BABAA";
						break;
					case 2:
						Encoding = "BAABA";
						break;
					case 3:
						Encoding = "BAAAB";
						break;
					case 4:
						Encoding = "ABBAA";
						break;
					case 5:
						Encoding = "AABBA";
						break;
					case 6:
						Encoding = "AAABB";
						break;
					case 7:
						Encoding = "ABABA";
						break;
					case 8:
						Encoding = "ABAAB";
						break;
					case 9:
						Encoding = "AABAB";
						break;
				}
				//Now that we have the total number including the check digit, determine character to print for proper barcoding:
				for(int I = 1;I <= EAN5AddOn.Length;I++)
				{
					//Get the value of each number.  It is encoded with variable parity
					int CurrentNumber = Convert.ToInt32(EAN5AddOn.Substring(I - 1, 1));
					//Print different barcodes according to the location of the CurrentChar and CurrentEncoding
					switch(Encoding.ToCharArray()[I - 1])
					{
						case 'A':
							if(CurrentNumber == 0) 
								EANAddOnToPrint.Append((char)34);
							if(CurrentNumber == 1) 
								EANAddOnToPrint.Append((char)35);
							if(CurrentNumber == 2) 
								EANAddOnToPrint.Append((char)36);
							if(CurrentNumber == 3) 
								EANAddOnToPrint.Append((char)37);
							if(CurrentNumber == 4) 
								EANAddOnToPrint.Append((char)38);
							if(CurrentNumber == 5) 
								EANAddOnToPrint.Append((char)44);
							if(CurrentNumber == 6) 
								EANAddOnToPrint.Append((char)46);
							if(CurrentNumber == 7) 
								EANAddOnToPrint.Append((char)47);
							if(CurrentNumber == 8) 
								EANAddOnToPrint.Append((char)58);
							if(CurrentNumber == 9) 
								EANAddOnToPrint.Append((char)59);
							break;

						case 'B':
							if(CurrentNumber == 0) 
								EANAddOnToPrint.Append((char)122);
							if(CurrentNumber == 1) 
								EANAddOnToPrint.Append((char)61);
							if(CurrentNumber == 2) 
								EANAddOnToPrint.Append((char)63);
							if(CurrentNumber == 3) 
								EANAddOnToPrint.Append((char)64);
							if(CurrentNumber == 4) 
								EANAddOnToPrint.Append((char)91);
							if(CurrentNumber == 5) 
								EANAddOnToPrint.Append((char)92);
							if(CurrentNumber == 6) 
								EANAddOnToPrint.Append((char)93);
							if(CurrentNumber == 7) 
								EANAddOnToPrint.Append((char)95);
							if(CurrentNumber == 8) 
								EANAddOnToPrint.Append((char)123);
							if(CurrentNumber == 9) 
								EANAddOnToPrint.Append((char)125);
							break;
					}
			
					//add in the space & add-on guard pattern
					switch(I)
					{
						case 1:
							EANAddOnToPrint.Insert(0, (char)43);  //add it to the front
							EANAddOnToPrint.Append((char)33);
							break;
							//Now print add-on delineators between each add-on character
						case 2:
							EANAddOnToPrint.Append((char)33);
							break;
						case 3:
							EANAddOnToPrint.Append((char)33);
							break;
						case 4:
							EANAddOnToPrint.Append((char)33);
							break;
						case 5:
							//EANAddOnToPrint = EANAddOnToPrint
							break;
					}
				} //end for loop
			}	//end 5 digit supplement work

			//Now for the 2 digit add on
			if(EAN2AddOn.Length == 2)
			{
				//Get encoding for add on
				string Encoding = "";
				for(int I = 0;I <= 99;I++)
				{
					if(Convert.ToInt32(EAN2AddOn) == I)
						Encoding = "AA";
					if(Convert.ToInt32(EAN2AddOn) == I + 1)
						Encoding = "AB";
					if(Convert.ToInt32(EAN2AddOn) == I + 2)
						Encoding = "BA";
					if(Convert.ToInt32(EAN2AddOn) == I + 3)
						Encoding = "BB";
				}//end for loop
          
				//Now that we have the total number including the encoding determine what to print
				for(int I = 1;I <= EAN2AddOn.Length;I++)
				{
					int CurrentNumber = Convert.ToInt32(EAN5AddOn.Substring(I - 1, 1));
					
					//Print different barcodes according to the location of the CurrentChar and CurrentEncoding
					switch(Encoding.ToCharArray()[I - 1])
					{
						case 'A':
							if(CurrentNumber == 0) 
								EANAddOnToPrint.Append((char)34);
							if(CurrentNumber == 1) 
								EANAddOnToPrint.Append((char)35);
							if(CurrentNumber == 2) 
								EANAddOnToPrint.Append((char)36);
							if(CurrentNumber == 3) 
								EANAddOnToPrint.Append((char)37);
							if(CurrentNumber == 4) 
								EANAddOnToPrint.Append((char)38);
							if(CurrentNumber == 5) 
								EANAddOnToPrint.Append((char)44);
							if(CurrentNumber == 6) 
								EANAddOnToPrint.Append((char)46);
							if(CurrentNumber == 7) 
								EANAddOnToPrint.Append((char)47);
							if(CurrentNumber == 8) 
								EANAddOnToPrint.Append((char)58);
							if(CurrentNumber == 9) 
								EANAddOnToPrint.Append((char)59);
							break;
						case 'B':
							if(CurrentNumber == 0) 
								EANAddOnToPrint.Append((char)122);
							if(CurrentNumber == 1) 
								EANAddOnToPrint.Append((char)61);
							if(CurrentNumber == 2) 
								EANAddOnToPrint.Append((char)63);
							if(CurrentNumber == 3) 
								EANAddOnToPrint.Append((char)64);
							if(CurrentNumber == 4) 
								EANAddOnToPrint.Append((char)91);
							if(CurrentNumber == 5) 
								EANAddOnToPrint.Append((char)92);
							if(CurrentNumber == 6) 
								EANAddOnToPrint.Append((char)93);
							if(CurrentNumber == 7) 
								EANAddOnToPrint.Append((char)95);
							if(CurrentNumber == 8) 
								EANAddOnToPrint.Append((char)123);
							if(CurrentNumber == 9) 
								EANAddOnToPrint.Append((char)125);
							break;
					} //end switch
					//add in the space & add-on guard pattern
					switch(I)
					{
						case 1:
							EANAddOnToPrint.Insert(0, (char)43);  //add it to the front
							EANAddOnToPrint.Append((char)33);
							break;
						case 2:
							break;
					}
				}//end loop thru characers
			} //end ean 2 digit supp processing

			//Now we have everything together
			sbOutput.Append(EANAddOnToPrint.ToString());
			return sbOutput.ToString();
		} //End UPCe

		string UCC128(string InputValue)
		{
			string tempInput = "";
			if(InputValue.Substring(0, 1).Equals("Ê") == false)
				tempInput = "Ê" + InputValue;
			else
				tempInput = InputValue;

			return Code128(tempInput, true);
		}			

		//This function will print a single bar code to the printer.  It takes in the name of 
		//the font to print, the encoded string, and the size of the font.  The string should 
		//be encoded by using one of the bar code functions included in this class.  Ensure 
		//that the font is installed on the computer before attempting to call this function.
		public void PrintBarCode(string TextFont, string EncodedText, float TextFontSize)
		{
			//Update the class variables
			lclFont = new Font(TextFont,TextFontSize);
			TextToPrint = EncodedText;
			
			//create the document object that will be printed.
			PrintDocument PrintDoc = new PrintDocument();
			
			//Call the print page method of the Print Document.  This assigns the event handler
			//that is used for printing operations of this bar code
			PrintDoc.PrintPage += new PrintPageEventHandler(this.PrintDocHandler);

			//now print the bar code.  Control will go to the event handler for any additional 
			//instructions for the printer, such as printing additional lines and
			//the location of the bar code on the page.
			PrintDoc.Print();
			
			return;
		}
		
		//This is the event handler for printing bar codes
		private void PrintDocHandler(object sender, PrintPageEventArgs ev)
		{
			//Vertical postion on page of bar code
			float yPos = 100;
			//Hotizontal position on the page of the bar code
			float xPos = 100;
			//Set the left margin of the page
			float leftMargin = ev.MarginBounds.Left;
			//set the top margin of the page.
			float topMargin = ev.MarginBounds.Top;
			
			//set the y pos to include the height of the text
			yPos = yPos + lclFont.GetHeight(ev.Graphics);

			//set the x pos to include the left margin of the page
			xPos = xPos + leftMargin;

			//send the string to the printer
			ev.Graphics.DrawString(TextToPrint, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
		}
	}//End Class
}//End Name Space