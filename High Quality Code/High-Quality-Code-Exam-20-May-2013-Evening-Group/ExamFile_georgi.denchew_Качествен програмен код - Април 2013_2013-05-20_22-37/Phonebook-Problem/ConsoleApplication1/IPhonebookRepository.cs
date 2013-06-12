using System.Collections.Generic;

namespace PhonebookApplication
{
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Method for adding phone numbers for a given name in the phonebook.
        /// </summary>
        /// <param name="name">String value, containing the name
        /// to which the phone numbers should be added</param>
        /// <param name="phoneNumbers">String values of phone number
        /// s to be added <remarks>String variables, containing phone numbers
        /// should be at least 1 and at most 10</remarks></param>
        /// <returns>A boolean representation of whether the given
        /// name already exists in the phonebook or not
        /// </returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes an old number from the phonebook entry with a new one.
        /// </summary>
        /// <param name="oldPhoneNumber">Number to be changed</param>
        /// <param name="newPhoneNumber">The new, updated number</param>
        /// <returns>An integer variable, containing the number of changed
        /// old phone numbers in the system</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// A list of the phonebook entries with paging.
        /// </summary>
        /// <param name="startIndex">Specifies the phonebook page</param>
        /// <param name="count">The number of entries to be retrieved</param>
        /// <returns>A list containing a certain number of entries
        /// from a certain page</returns>
        /// <remarks>All entries are sorted by name - case-insensitive</remarks>
        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}
