=========> ĐỌC KĨ HƯỚNG DẪN SỬ DỤNG <==============
1-không xóa và sửa bất cứ file nào trong thư mục 
"DATA" và các thư mục khác cũng như các file đi 
kèm nằm ngoài các thư mục
===================================================
ngoại trừ file "Creat_database.bat" và
file "Create_database_VERSION_SQLEXPRESS.bat" 
file này chỉ đưuọc sửa theo hướng dẫn 
không được xóa
====================================================
2 -Trước khi sử dụng phần mềm bạn hãy 
Chạy file "Create_database.bat" 
hoặc "Create_database_VERSION_SQLEXPRESS.bat" 
để tạo cở sở dữ liệu cho phần mềm.
====================================================
============> CHÚ Ý QUAN TRỌNG   <==================
Nếu nhứ trên máy của bạn cài đặt SQL SERVER 
phiên bản EXPRESS" thì bạn chạy file 
"Create_database_VERSION_SQLEXPRESS.bat" 
Nếu không phải phiên bản "EXPRESS" 
thì bạn chạy file "Create_database.bat"


Trong trường hợp bạn không biết phiên bản SQL SERVER 
trên máy của mình là phiên bản nào thì 
có thể chạy chạy cả hai file
		
Làm theo hướng dẫn bên dưới để chạy file tạo database
như đã nói ở trên


===============================================================================================
====> CÁCH CHẠY:
B1 Bạn click chuột phải lên file "Create database.bat" 
chọn edit sau đó bạn đổi đường dẫn đến thư mục DATA 
ví dụ: khi bạn chọn edit xong thì sẽ thấy 
một dòng lệnh như sau: 
=> "sqlcmd -E -S .\SQLExpress -i C:\Users\TPT\Desktop\DATA\HRM_sql_V4.sql"
Trong đó bạn sẽ thấy đường dẫn đến thư mục DATA 
sẽ bắt đầu từ sau kí tự "-i " cho đến trước kí tự "DATA"(là tên thư mục)
================================================================================================
" Lưu ý bạn chỉ đổi đoạn kí tự được hướng dẫn những phần còn lại không được thay đổi"
================================================================================================
===> Lúc này bạn sẽ chuyển thành đường link dẫn đến file DATA trên máy của bạn 
Sau đó bấm tổ hợp phím "Ctrl + S" để lưu lại sau đó bạn thực hiện theo hướng dẫn ở bước 2
B2 click chuột phải lên file "Create database.bat" chọn "Run as Administrator"
hộp thoại xuất hiện bạn chọn "yes" sau đó đợi màn hình dòng lệnh CMD chạy 
xong thì bạn có thể sử dụng phần mềm. Cảm ơn bạn đã đọc hướng dẫn này.

		=========> CHÚ Ý QUAN TRỌNG <===========
		nếu làm tương tự hướng dẫn mà không chạy 
		được phần mềm thì bạn hay làm tương tự 
		nhưng đối với file 
		"Create_database_VERSION_SQLEXPRESS.bat"
==================================================================================================
