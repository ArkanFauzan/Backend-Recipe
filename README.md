# Recipe Management API

# Cara instalasi

clone repository <br>
git clone https://github.com/ArkanFauzan/Backend-Recipe.git

jalankan command <br>
cd Backend-Recipe

jalankan command <br>
dotnet restore

buat appsettings.json dan sesuaikan connection dan secret key. Strukturnya dapat dilihat dari _appsettings.json_example

jalankan command <br>
dotnet ef database update

jalankan command <br>
dotnet run

buka http://localhost:5184/swagger/index.html

Akun login dapat menggunakan: <br>
Username = superadmin <br>
Password = 12345678

Apabila diperlukan database yang sudah ada isinya, lakukan import dari file sql berikut: <br> 
https://github.com/ArkanFauzan/Backend-Recipe/blob/main/recipe_db.sql

# ERD
![ERD](Screenshots/ERD.png)

# Penjelasan ERD
- Table DataTypes
  - Berfungsi untuk CRUD Tipe Data
  - Terdapat beberapa jenis validasi data, seperti integer, float, dan custom regex
  - Custom regex dapat digunakan apabila diperlukan data dengan kriteria tertentu, misalnya angka dari 1-100
  - Contoh pengisian data:
    - Name            || ParseType    || CustomRegex
    - Integer         || INTEGER      || ""
    - Float           || FLOAT        || ""
    - Integer (1-100) || CUSTOM_REGEX || "^(100|[1-9][0-9]?$)"
- Table StepParameterTemplates
  - Berfungsi sebagai parameter template
  - Parameter seperti deskripsi, suhu, tekanan, bisa terdapat di banyak step/langkah
  - Dapat memudahkan pengisian step parameter
  - Contoh pengisian data:
    - Name            || DataTypeId    || Description
    - Suhu            || uuid Float    || "Suhu yang digunakan"
    - Tekanan         || uuid Float    || "Tekanan alat yang digunakan"
    - Durasi          || uuid Integer  || "Lama waktu pelaksanaan langkah"
- Table StepParameters
  - Berfungsi sebagai parameter dari suatu step/langkah
  - Kolom Value berisi nilai dari parameter tersebut
  - Kolom Note dapat berisi keterangan/unit/satuan dari Value (karena pada StepParameterTemplate masih deskripsi umum)
  - Contoh pengisian data:
    - StepId            || StepParameterTemplateId    || Value || Note
    - uuid step         || uuid Suhu                  || 80    || "°C"
    - uuid step         || uuid Durasi                || 30    || "Menit"
- Table Steps
  - Berisi langkah-langkah pembuatan resep, bersifat dapat memiliki unlimited sub-step
  - Kolom Depth berfungsi sebagai flag level kedalaman sub-step
  - Kolom Order (integer) berfungsi sebagai urutan langkah pada level yang setara
- Table Recipe
  - Berisi daftar recipe

- Table Permission
  - seperti "recipe"
- Table PermissionMethod
  - seperti "recipe.view", "recipe.create", "recipe.update", "recipe.delete"
- Table Role
  - seperti "Super Admin"
- Table RolePermissionMethods
  - berisi mapping antara Role dengan PermissionMethod
- Table Accounts
  - berisi data user/pengguna


# 📸 Screenshots

![01](Screenshots/01-api-recipe-list.png) <br><br>
![02](Screenshots/02-api-recipe.png) <br><br>
![03](Screenshots/03-api-recipe-detail.png) <br><br>
![04](Screenshots/04-api-recipe-detail-full-step.png) <br><br>
![05](Screenshots/05-api-recipe-detail-full-step-parameter.png) <br><br>
![06](Screenshots/06-api-step.png) <br><br>
![07](Screenshots/07-api-step-detail.png) <br><br>
![08](Screenshots/08-api-step-detail-full-step.png) <br><br>
![09](Screenshots/09-api-step-detail-parameter.png) <br><br>
![10](Screenshots/10-pembuatan-tipe-data.png) <br><br>
![11](Screenshots/11-pembuatan-tipe-data-regex.png) <br><br>
![12](Screenshots/12-opsi-parse-type.png) <br><br>
![13](Screenshots/13-pembuatan-step-parameter-template.png) <br><br>
![14](Screenshots/14-pembuatan-recipe.png) <br><br>
![15](Screenshots/15-pembuatan-step-top-level.png) <br><br>
![16](Screenshots/16-pembuatan-step-untuk-sub-step.png) <br><br>
![17](Screenshots/17-pembuatan-step-parameter-contoh1.png) <br><br>
![18](Screenshots/18-pembuatan-step-parameter-contoh2.png) <br><br>
![19](Screenshots/19-pembuatan-step-parameter-contoh3.png) <br><br>
![20](Screenshots/20-mengubah-urutan-step-atau-langkah.png)
