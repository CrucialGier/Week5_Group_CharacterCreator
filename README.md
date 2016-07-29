###_Laser Pants_

#### _29 July 2016_

#### By _**Stewart Cole, Cassandra Culkins Bhawani Parajuli, Josh Bertsche**_

## Description
It's a fun website that let's you customize different types of characters with fun features. It can only be used in windows right now.

### Technologies Used
HTML, CSS, JavaScript, jQuery, Bootstrap, C#, Nancy, Razor, SQL

### Setup and Installation
Requred downloads:
Microsoft SQL Server Management Studio
Windows Powershell
Chocolatey
Ruby


Setup:
Install Chocolatey in Windows powershell(run as administrator) if you want to contribute using the following command in the window powershell:
iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
Once the chocolatey is installed install ruby using following command: choco install ruby
It is followed with the following command: Do you want to run the script?([Y]es/[N]o/[P]rint):
Type y to approve.
Close the andministrator window and open the regular window and type in the following command: gem install pivotal_git_scripts
You should be set to clone the repository.
Clone repo on the powershell.
Execute CharacterCreatorDBS script on the Microsoft SQL Server Management Studio to setup database.
The script should begin with :
CREATE DATABASE character_creator
GO
On the powershell run: dnu restore
Then run: dnx kestrel
Now the app should be ready to launch.
Open the web browser and run: http:\\localhost:5004.

###Known Bugs
The load page won't display any image.
### License

MIT License

Copyright (c) 2016 **_Stewart Cole, Cassandra Culkins Bhawani Parajuli, Josh Bertsche _**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
