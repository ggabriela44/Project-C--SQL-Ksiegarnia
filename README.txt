Main program run : Ksiegarnia.sln

The project presents an online book store from the admin view.
For its needs, 6 tables were created: Book, Genre, BookOrder, Order, Delivery, Customer. The BookOrder table is the intermediary table, a many-to-many relationship between the Order and Book tables.

As part of the project, an additional service layer was created. It mediates in communication between the controller and the repository layer.


"Book" table
The web application automatically opens a page with books available in the store. They are displayed in tiles, where each tile with a book has buttons to edit, see more details about a given book, or delete one of them. Also in the lower right corner of the page there is a button to add a new book to the database. Validation in forms is also introduced.
An example of displaying detailed information about a book.


"Customers" table
It shows all information about customers and their data. We can use the buttons: Add, Edit or Delete to perform actions on the database of each customer: add, edit data or delete a given customer.


"Order" table
We can edit the table, add new records to it, or delete records by pressing the appropriate buttons.


Species table
We can edit the table, add new records to it, or delete records by pressing the appropriate buttons.


"Delivery" table
We can edit the table, add new records to it, or delete records by pressing the appropriate buttons.

©Copyright Gabriela Górliñska