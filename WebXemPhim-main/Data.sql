﻿﻿﻿
create database webmovie
go

use webmovie
go

create table AdminPro(
id int identity primary key,
ten_admin nvarchar(50),
mat_khau_admin nvarchar(50)
)
go

create table Loai(
id_loai int identity primary key,
ten_loai nvarchar(50)
)
go

create table QuocGia(
id_quoc_gia int identity primary key,
ten_quoc_gia nvarchar(50),
)
go

create table DienVien(
id_dien_vien int identity primary key,
ten_dien_vien nvarchar(50),
anh_bia nvarchar(100)
)
go

create table NamPhatHanh(
id_nam int identity primary key,
nam_phat_hanh int
)
go

create table TrangThai(
id_trang_thai int identity primary key,
ten_trang_thai nvarchar(50)
)
go

create table NguoiDung(
id_nguoi_dung int identity primary key,
ten_nguoi_dung nvarchar(50),
tai_khoan nvarchar(50),
mat_khau nvarchar(50),
email nvarchar(50),
trang_thai nvarchar(30),

)
go



create table Phim(
id_phim int identity primary key,
ten_phim nvarchar(50),
anh_bia nvarchar(100),
id_loai int,
mo_ta nvarchar(2000),
trailer nvarchar(100),
link_phim nvarchar(150),
id_trang_thai int,
id_quoc_gia int,
id_nam int,
CONSTRAINT FK_trangthai_phim FOREIGN KEY (id_trang_thai) REFERENCES TrangThai(id_trang_thai),
CONSTRAINT FK_quocgia_phim FOREIGN KEY (id_quoc_gia) REFERENCES quocgia(id_quoc_gia),
CONSTRAINT FK_namphathanh_phim FOREIGN KEY (id_nam) REFERENCES NamPhatHanh(id_nam),
CONSTRAINT FK_loai_phim FOREIGN KEY (id_loai) REFERENCES Loai(id_loai),

)
go

create table Phim_Dienvien(
id_phim int,
id_dien_vien int,
PRIMARY KEY (id_phim,id_dien_vien),
CONSTRAINT FK_dv_phim FOREIGN KEY (id_dien_vien) REFERENCES dienvien(id_dien_vien),
CONSTRAINT FK_phim_dv FOREIGN KEY (id_phim) REFERENCES phim(id_phim)
)
go

create table ChiTietLoai(
id_phim int,
id_loai int,
PRIMARY KEY (id_phim,id_loai),
CONSTRAINT FK_loai_ctl FOREIGN KEY (id_loai) REFERENCES loai(id_loai),
CONSTRAINT FK_phim_ctl FOREIGN KEY (id_phim) REFERENCES phim(id_phim)
)
go

create table BinhLuan(
id_binh_luan int identity primary key,
id_nguoi_dung int,
id_phim int,
noi_dung nvarchar(200),
ngay_binh_luan date,
trang_thai nvarchar(30),
CONSTRAINT FK_phim_binhloan FOREIGN KEY (id_phim) REFERENCES Phim(id_phim),
CONSTRAINT FK_nd_binhluan FOREIGN KEY (id_nguoi_dung) REFERENCES NguoiDung(id_nguoi_dung)
)
go



create table DanhGia(
id_nguoi_dung int,
id_phim int,
diem int,
tong_diem int,
PRIMARY KEY (id_phim,id_nguoi_dung),
CONSTRAINT FK_kh_danhgia FOREIGN KEY (id_phim) REFERENCES phim(id_phim),
CONSTRAINT FK_phim_danhgia FOREIGN KEY (id_nguoi_dung) REFERENCES NguoiDung(id_nguoi_dung)
)
go

delete Loai
DBCC CHECKIDENT (Loai, RESEED, 0)
DBCC CHECKIDENT (Loai)
insert into loai values ('Phiêu Lưu'),(N'Hành Động'),(N'Nhập Vai'),(N'Kinh Dị')



delete NamPhatHanh
DBCC CHECKIDENT (NamPhatHanh, RESEED, 0)
DBCC CHECKIDENT (NamPhatHanh)
insert into NamPhatHanh(nam_phat_hanh) values (2000)
insert into NamPhatHanh(nam_phat_hanh) values (2001)
insert into NamPhatHanh(nam_phat_hanh) values (2002)
insert into NamPhatHanh(nam_phat_hanh) values (2003)
insert into NamPhatHanh(nam_phat_hanh) values (2004)
insert into NamPhatHanh(nam_phat_hanh) values (2005)
insert into NamPhatHanh(nam_phat_hanh) values (2006)
insert into NamPhatHanh(nam_phat_hanh) values (2007)
insert into NamPhatHanh(nam_phat_hanh) values (2008)
insert into NamPhatHanh(nam_phat_hanh) values (2009)
insert into NamPhatHanh(nam_phat_hanh) values (2010)

delete QuocGia
DBCC CHECKIDENT (QuocGia, RESEED, 0)
DBCC CHECKIDENT (QuocGia)
insert into QuocGia(ten_quoc_gia) values (N'Việt Nam')
insert into QuocGia(ten_quoc_gia) values (N'Trung Quốc')
insert into QuocGia(ten_quoc_gia) values (N'Hàn Quốc')
insert into QuocGia(ten_quoc_gia) values (N'Nhật Bản')
insert into QuocGia(ten_quoc_gia) values (N'Thái Lan')


delete DienVien
DBCC CHECKIDENT (DienVien, RESEED, 0)
DBCC CHECKIDENT (DienVien)
insert into DienVien values (N'Châu Tinh Trì',N'dienvien1.jpg')
insert into DienVien values (N'Diệp Vấn',N'dienvien2.jpg')
insert into DienVien values (N'Lý Tiểu Long',N'dienvien3.jpg')

delete TrangThai
DBCC CHECKIDENT (TrangThai, RESEED, 0)
DBCC CHECKIDENT (TrangThai)
insert into TrangThai values (N'Đã Phát Hành')
insert into TrangThai values (N'Chưa Phát Hành')

delete NguoiDung
DBCC CHECKIDENT (NguoiDung, RESEED, 0)
DBCC CHECKIDENT (NguoiDung)
insert into NguoiDung values (N'Đinh Hoàng Long',N'long',N'123','hlong006@gmail.com',N'Đang Hoạt Động')


delete AdminPro
DBCC CHECKIDENT (AdminPro, RESEED, 0)
DBCC CHECKIDENT (AdminPro)
insert into AdminPro values (N'admin',N'123')

delete Phim
DBCC CHECKIDENT (Phim, RESEED, 0)
DBCC CHECKIDENT (Phim)
insert into Phim values (N'Paranomal Activity',N'Paranormal_Activity.jpg',1,N'Tháng Chín năm 2006, một cặp vợ chồng trẻ là Katie và Micah chuyển đến sống tại một ngôi nhà mới ở San Diego. Katie nói với Micah rằng ma quỷ đang ám ảnh cô ấy. Sau đó Micah lấp đặt một máy quay phim trong phòng ngủ của họ để ghi lại những hoạt động xảy ra trong khi họ ngủ.Trải qua từng đêm, hiện tượng kỳ lạ được ghi nhận trong máy quay, chẳng hạn như tiếng ồn, ánh sáng nhấp nháy và cửa ra vào tự chuyển động. Trong đêm 15, Katie bị mộng du, cô đứng bên cạnh phía giường Micah và nhìn chằm chằm vào anh ta trong hai giờ trước khi đi ra ngoài. Micah cố gắng thuyết phục Katie quay trở lại bên trong, nhưng cô từ chối và dường như cô quên nó ngay vào ngày hôm sau.Đêm sau, Katie ra khỏi giường và nhìn chằm chằm vào Micah trong hai giờ trước khi đi xuống cầu thang. Sau một lúc im lặng, Katie hét lên tên Micah cùng với một giọng nói kì lạ, ông vội chạy đến cô. Dừng la hét, Katie bước đi lên cầu thang. Cô ném cơ thể của Micah vào phía máy quay. Cô từ từ bước vào phòng, lại gần cơ thể Micah và sau đó nhìn lên máy ảnh với một nụ cười. Khi cô hướng về phía máy ảnh, khuôn mặt của cô mang một diện mạo ma quỷ. Cuối phim, một văn bản bằng lời rằng cơ thể Micah được phát hiện bởi cảnh sát ngày 11 tháng 10 năm 2006, và nơi ở của Katie vẫn chưa được biết.','https://www.youtube.com/embed/F_UxLEqd074','https://www.youtube.com/embed/zuPFCO20BD0',1,1,1)
insert into Phim values (N'Chuyên Gia Xảo Quyệt',N'chuyen-gia-xao-quyet.jpg',2,N'Chuyên Gia Xảo Quyệt kể về vua hài Châu Tinh Trì vào vai tên lừa đảo Koo chuyên nghiệp. Được Waise Lee thuê để tìm cách trả thù Lưu Đức Hòa trong công việc. Koo nhận nhiệm vụ và giả dạng thành em trai lưu lạc của Lưu Đức Hòa. Từ đó Ko phải tiếp xúc và va chạm với gia đình của Lưu để hoàn thành công việc đã giao. Liệu Koo có tiếp tục công việc mà Lee đã giao phó là hạ gục Lưu hay Koo sẽ bị cảm hóa bởi gia đình của Lưu.','https://www.youtube.com/embed/gJHK0U5UzvU','https://www.youtube.com/embed/wN3QLcICvHs',1,3,2)
insert into Phim values (N'World War Z',N'WorldWarZ.jpg',3,N'Lấy bối cảnh tận thế năm 2013 của Mỹ do Marc Forster đạo diễn, với kịch bản do Matthew Michael Carnahan, Drew Goddard và Damon Lindelof viết, dựa trên cuốn tiểu thuyết cùng tên năm 2006 của Max Brooks. Phim có sự tham gia của Brad Pitt trong vai Gerry Lane, một cựu điều tra viên của Liên Hợp Quốc, người phải đi khắp thế giới để tìm cách ngăn chặn đại dịch Zombie.[5] Dàn diễn viên phụ bao gồm Mireille Enos, Lucy Aharish, Daniella Kertesz, James Badge Dale, Ludi Boeken, Fana Mokoena, David Morse, Peter Capaldi, Pierfrancesco Favino, Ruth Negga và David Andrew.Kế hoạch B Entertainment của Pitt đã bảo đảm bản quyền phim vào năm 2007 và Forster được tiếp cận để chỉ đạo. Năm 2009, Carnahan được thuê để viết lại kịch bản. Việc quay phim bắt đầu vào tháng 7 năm 2011 tại Malta, với kinh phí ước tính 125 triệu đô la, trước khi chuyển đến Glasgow vào tháng 8 năm 2011 và Budapest vào tháng 10 năm 2011. Ban đầu dự định sẽ phát hành tháng 12 năm 2012, việc sản xuất bị một số thất bại. Vào tháng 6 năm 2012, ngày phát hành của bộ phim đã bị đẩy lùi và đoàn làm phim quay trở lại Budapest trong bảy tuần quay thêm.','https://www.youtube.com/embed/Md6Dvxdr0AQ','https://www.youtube.com/embed/TvVzNlJg4Ak',1,4,1)
insert into Phim values (N'Insidious 2',N'Insidious.jpg',2,N'Năm 1986, Lorraine Lambert mời nhà tâm linh Elise đến nhà mình để giúp tìm con ma đang đeo bám cậu con trai Josh của bà. Elise nhận định Josh có khả năng đặc biệt mà người thường không có, đó là kết nối linh hồn mình với thế giới của người chết.Hai mươi lăm năm trôi qua, Josh khi này đã có vợ là Renai cùng hai con.Những tưởng đã thoát khỏi ma quỷ từ lần trước nhưng những hiện tượng lạ vẫn diễn ra trong nhà Lambert. Hồn ma được cho là của Elise bảo họ đến một bệnh viện mà trước đây Lorraine từng làm việc (nay đã bỏ hoang). Tại đây, khi đi tới phòng chăm sóc tăng cường, Lorraine kể lại câu chuyện về một bệnh nhân già tên là Parker Crane và chuyện bà đã gặp hồn ma của ông ta lang thang trong bệnh viện. Họ tìm địa chỉ nhà Crane và đến đó. Tại đây họ đã phát hiện ra sự thật kinh hoàng: linh hồn dẫn họ đến đây không phải là Elise mà là mẹ của Parker Crane. Họ phát hiện một phòng nọ chứa đầy các xác chết đầu đội khăn trắng. Thì ra Parker Crane - dưới sự sai khiến của mẹ y - là một kẻ giết người hàng loạt với biệt danh "Cô dâu mặc đồ đen" do mỗi khi giết người, y lại trang điểm như đàn bà và mặc váy đen và lúc này hắn đã chiếm được linh hồn của Josh vì hắn muốn có lại tuổi thơ.','https://www.youtube.com/embed/fBbi4NeebAk','https://www.youtube.com/embed/XfgT6RiDo3Y',1,2,1)
insert into Phim values (N'Overlord',N'Overlord.jpg',1,N'Overlord lấy bối cảnh vào năm 2138 trong tương lai, khi khoa học công nghệ phát triển vượt bậc và ngành game thực tế ảo đang nở rộ hơn bao giờ hết. Câu chuyện bắt đầu trong những giây phút cuối tại tại Yggdrasil, một game online đình đám sắp phải đóng cửa. Nhân vật chính Momonga quyết định ở lại đến tận những phút cuối cùng với trò chơi yêu thích của mình và chờ server down. Bất ngờ, server không shutdown, Momonga bị mắc kẹt trong nhân vật của chính mình và dịch chuyển tới một thế giới khác. Vị chúa tể hùng mạnh của đại lăng tẩm Nazarick giờ đây lại tiếp tục đi khám phá thế giới mới và đối mặt với những thử thách mới. Không gia đình, bạn bè, địa vị xã hội, người đàn ông bình thường ấy sẽ cố gắng hết sức để thống trị thế giới mới này.','https://www.youtube.com/embed/uhlBqFj9kDw','https://www.youtube.com/embed/73v8UBp0Fso',1,2,1)

delete ChiTietLoai
insert into ChiTietLoai values (1,1)
insert into ChiTietLoai values (1,3)
insert into ChiTietLoai values (1,2)
insert into ChiTietLoai values (2,2)
insert into ChiTietLoai values (2,3)
insert into ChiTietLoai values (3,3)
insert into ChiTietLoai values (3,1)
insert into ChiTietLoai values (4,4)
insert into ChiTietLoai values (5,4)

delete Phim_Dienvien
insert into Phim_Dienvien values (1,1)
insert into Phim_Dienvien values (1,2)
insert into Phim_Dienvien values (2,1)
insert into Phim_Dienvien values (2,0)
insert into Phim_Dienvien values (3,0)

