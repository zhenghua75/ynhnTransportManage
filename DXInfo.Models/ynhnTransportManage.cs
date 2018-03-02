
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DXInfo.Models 
{		
		 			
		public class Driver							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String Code {get ;set;}						
							    
			public String Name {get ;set;}						
							    
			public String DriverNo {get ;set;}						
							    
			public String Telephone {get ;set;}						
							    
			public String Address {get ;set;}						
							    
			public String IdCardNo {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class aspnet_User							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid ApplicationId {get ;set;}						
							    
			public Guid UserId {get ;set;}						
							    
			public String UserName {get ;set;}						
						
			[Key]
			[Column(Order=1)]
						    
			public String LoweredUserName {get ;set;}						
							    
			public String MobileAlias {get ;set;}						
							    
			public Boolean IsAnonymous {get ;set;}						
							    
			public DateTime LastActivityDate {get ;set;}						
					
		}							
			 			
		public class aspnet_SchemaVersion							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public String Feature {get ;set;}						
						
			[Key]
			[Column(Order=1)]
						    
			public String CompatibleSchemaVersion {get ;set;}						
							    
			public Boolean IsCurrentVersion {get ;set;}						
					
		}							
			 			
		public class aspnet_Membership							
		{
						    
			public Guid ApplicationId {get ;set;}						
						
			[Key]
			[Column(Order=0)]
						    
			public Guid UserId {get ;set;}						
							    
			public String Password {get ;set;}						
							    
			public Int32 PasswordFormat {get ;set;}						
							    
			public String PasswordSalt {get ;set;}						
							    
			public String MobilePIN {get ;set;}						
							    
			public String Email {get ;set;}						
							    
			public String LoweredEmail {get ;set;}						
							    
			public String PasswordQuestion {get ;set;}						
							    
			public String PasswordAnswer {get ;set;}						
							    
			public Boolean IsApproved {get ;set;}						
							    
			public Boolean IsLockedOut {get ;set;}						
							    
			public DateTime CreateDate {get ;set;}						
							    
			public DateTime LastLoginDate {get ;set;}						
							    
			public DateTime LastPasswordChangedDate {get ;set;}						
							    
			public DateTime LastLockoutDate {get ;set;}						
							    
			public Int32 FailedPasswordAttemptCount {get ;set;}						
							    
			public DateTime FailedPasswordAttemptWindowStart {get ;set;}						
							    
			public Int32 FailedPasswordAnswerAttemptCount {get ;set;}						
							    
			public DateTime FailedPasswordAnswerAttemptWindowStart {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class UnitOfMeasure							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String Code {get ;set;}						
							    
			public String Name {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class Vehicle							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String PlateNo {get ;set;}						
							    
			public String BrandModel {get ;set;}						
							    
			public String MotorNo {get ;set;}						
							    
			public String Comment {get ;set;}						
							    
			public String OwnerName {get ;set;}						
					
		}							
			 			
		public class aspnet_Profile							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid UserId {get ;set;}						
							    
			public String PropertyNames {get ;set;}						
							    
			public String PropertyValuesString {get ;set;}						
							    
			public Byte[] PropertyValuesBinary {get ;set;}						
							    
			public DateTime LastUpdatedDate {get ;set;}						
					
		}							
			 			
		public class Transport							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public Guid Card {get ;set;}						
							    
			public DateTime InFactory_Date {get ;set;}						
							    
			public Guid InFactory_UserId {get ;set;}						
							    
			public Guid InFactory_DeptId {get ;set;}						
							    
			public DateTime? Load_Date {get ;set;}						
							    
			public Guid? Load_UserId {get ;set;}						
							    
			public Guid? Load_DeptId {get ;set;}						
							    
			public Guid? Load_Inventory {get ;set;}						
							    
			public Decimal? Load_Quantity {get ;set;}						
							    
			public DateTime? Shipment_Date {get ;set;}						
							    
			public Guid? Shipment_UserId {get ;set;}						
							    
			public Guid? Shipment_DeptId {get ;set;}						
							    
			public Decimal? Shipment_Quantity {get ;set;}						
							    
			public String Shipment_CheckUser {get ;set;}						
							    
			public DateTime? OutFactory_Date {get ;set;}						
							    
			public Guid? OutFactory_UserId {get ;set;}						
							    
			public Guid? OutFactory_DeptId {get ;set;}						
							    
			public Guid? BalanceType {get ;set;}						
							    
			public Decimal? AgreeFreightRate {get ;set;}						
							    
			public Decimal? FreightRate {get ;set;}						
							    
			public String Comment {get ;set;}						
							    
			public String Shipper {get ;set;}						
							    
			public String Shipper_Telephone {get ;set;}						
							    
			public String Carrier {get ;set;}						
							    
			public String Carrier_Telephone {get ;set;}						
							    
			public Guid? Lines {get ;set;}						
							    
			public Guid? Driver {get ;set;}						
							    
			public Int32 Status {get ;set;}						
							    
			public Guid? ModifyUserId {get ;set;}						
							    
			public Guid? ModifyDeptId {get ;set;}						
							    
			public DateTime? ModifyDate {get ;set;}						
					
		}							
			 			
		public class TransportsLog							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public Guid tpId {get ;set;}						
							    
			public Guid Card {get ;set;}						
							    
			public DateTime InFactory_Date {get ;set;}						
							    
			public Guid InFactory_UserId {get ;set;}						
							    
			public Guid InFactory_DeptId {get ;set;}						
							    
			public DateTime? Load_Date {get ;set;}						
							    
			public Guid? Load_UserId {get ;set;}						
							    
			public Guid? Load_DeptId {get ;set;}						
							    
			public Guid? Load_Inventory {get ;set;}						
							    
			public Decimal? Load_Quantity {get ;set;}						
							    
			public DateTime? Shipment_Date {get ;set;}						
							    
			public Guid? Shipment_UserId {get ;set;}						
							    
			public Guid? Shipment_DeptId {get ;set;}						
							    
			public Decimal? Shipment_Quantity {get ;set;}						
							    
			public String Shipment_CheckUser {get ;set;}						
							    
			public DateTime? OutFactory_Date {get ;set;}						
							    
			public Guid? OutFactory_UserId {get ;set;}						
							    
			public Guid? OutFactory_DeptId {get ;set;}						
							    
			public Guid? BalanceType {get ;set;}						
							    
			public Decimal? AgreeFreightRate {get ;set;}						
							    
			public Decimal? FreightRate {get ;set;}						
							    
			public String Comment {get ;set;}						
							    
			public String Shipper {get ;set;}						
							    
			public String Shipper_Telephone {get ;set;}						
							    
			public String Carrier {get ;set;}						
							    
			public String Carrier_Telephone {get ;set;}						
							    
			public Guid? Lines {get ;set;}						
							    
			public Guid? Driver {get ;set;}						
							    
			public Int32 Status {get ;set;}						
							    
			public Guid? ModifyUserId {get ;set;}						
							    
			public Guid? ModifyDeptId {get ;set;}						
							    
			public DateTime? ModifyDate {get ;set;}						
					
		}							
			 			
		public class Card							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String CardNo {get ;set;}						
							    
			public String SecondCardNo {get ;set;}						
							    
			public Guid Vehicle {get ;set;}						
							    
			public DateTime CreateDate {get ;set;}						
							    
			public Guid LossUserId {get ;set;}						
							    
			public DateTime? LossDate {get ;set;}						
							    
			public Guid FoundUserId {get ;set;}						
							    
			public DateTime? FoundDate {get ;set;}						
							    
			public DateTime? AddDate {get ;set;}						
							    
			public Guid? AddUserId {get ;set;}						
							    
			public Guid UserId {get ;set;}						
							    
			public Guid DeptId {get ;set;}						
							    
			public Int32 Status {get ;set;}						
							    
			public String Comment {get ;set;}						
							    
			public String AddReason {get ;set;}						
					
		}							
			 			
		public class ekey							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public String HardwareID {get ;set;}						
							    
			public String CardNo {get ;set;}						
							    
			public DateTime CreateDate {get ;set;}						
							    
			public Boolean IsUse {get ;set;}						
							    
			public Guid? UserId {get ;set;}						
					
		}							
			 			
		public class aspnet_Role							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid ApplicationId {get ;set;}						
							    
			public Guid RoleId {get ;set;}						
							    
			public String RoleName {get ;set;}						
						
			[Key]
			[Column(Order=1)]
						    
			public String LoweredRoleName {get ;set;}						
							    
			public String Description {get ;set;}						
					
		}							
			 			
		public class Line							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String Code {get ;set;}						
							    
			public String Name {get ;set;}						
							    
			public Decimal? Mileage {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class aspnet_UsersInRole							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid UserId {get ;set;}						
						
			[Key]
			[Column(Order=1)]
						    
			public Guid RoleId {get ;set;}						
					
		}							
			 			
		public class aspnet_Sitemap							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public String Code {get ;set;}						
							    
			public String Title {get ;set;}						
							    
			public String Description {get ;set;}						
							    
			public String Controller {get ;set;}						
							    
			public String Action {get ;set;}						
							    
			public String ParaId {get ;set;}						
							    
			public String Url {get ;set;}						
							    
			public String ParentCode {get ;set;}						
							    
			public Boolean IsAuthorize {get ;set;}						
							    
			public Boolean IsMenu {get ;set;}						
					
		}							
			 			
		public class aspnet_AuthorizationRule							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid RuleId {get ;set;}						
							    
			public String SiteMapKey {get ;set;}						
							    
			public Guid? RoleId {get ;set;}						
							    
			public Guid? UserId {get ;set;}						
					
		}							
			 			
		public class NameCode							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid ID {get ;set;}						
							    
			public String Type {get ;set;}						
							    
			public String Code {get ;set;}						
							    
			public String Name {get ;set;}						
							    
			public String Value {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class aspnet_Path							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid ApplicationId {get ;set;}						
							    
			public Guid PathId {get ;set;}						
							    
			public String Path {get ;set;}						
						
			[Key]
			[Column(Order=1)]
						    
			public String LoweredPath {get ;set;}						
					
		}							
			 			
		public class Inventory							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid Id {get ;set;}						
							    
			public String Code {get ;set;}						
							    
			public String Name {get ;set;}						
							    
			public Guid? UnitOfMeasure {get ;set;}						
							    
			public String Specs {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class aspnet_PersonalizationAllUser							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid PathId {get ;set;}						
							    
			public Byte[] PageSettings {get ;set;}						
							    
			public DateTime LastUpdatedDate {get ;set;}						
					
		}							
			 			
		public class Dept							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid DeptId {get ;set;}						
							    
			public Guid? ParentDeptId {get ;set;}						
							    
			public String Address {get ;set;}						
							    
			public String DeptCode {get ;set;}						
							    
			public String DeptName {get ;set;}						
							    
			public Guid? Manager {get ;set;}						
							    
			public String Comment {get ;set;}						
					
		}							
			 			
		public class aspnet_PersonalizationPerUser							
		{
						    
			public Guid Id {get ;set;}						
							    
			public Guid? PathId {get ;set;}						
							    
			public Guid? UserId {get ;set;}						
							    
			public Byte[] PageSettings {get ;set;}						
							    
			public DateTime LastUpdatedDate {get ;set;}						
					
		}							
			 			
		public class adj_table							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Int32 emp_id {get ;set;}						
							    
			public String name {get ;set;}						
							    
			public Decimal? salary {get ;set;}						
							    
			public Int32? boss_id {get ;set;}						
					
		}							
			 			
		public class aspnet_WebEvent_Event							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public String EventId {get ;set;}						
							    
			public DateTime EventTimeUtc {get ;set;}						
							    
			public DateTime EventTime {get ;set;}						
							    
			public String EventType {get ;set;}						
							    
			public Decimal EventSequence {get ;set;}						
							    
			public Decimal EventOccurrence {get ;set;}						
							    
			public Int32 EventCode {get ;set;}						
							    
			public Int32 EventDetailCode {get ;set;}						
							    
			public String Message {get ;set;}						
							    
			public String ApplicationPath {get ;set;}						
							    
			public String ApplicationVirtualPath {get ;set;}						
							    
			public String MachineName {get ;set;}						
							    
			public String RequestUrl {get ;set;}						
							    
			public String ExceptionType {get ;set;}						
							    
			public String Details {get ;set;}						
					
		}							
			 			
		public class aspnet_CustomProfile							
		{
					
			[Key]
			[Column(Order=0)]
						    
			public Guid UserId {get ;set;}						
							    
			public Guid? DeptId {get ;set;}						
							    
			public String FullName {get ;set;}						
							    
			public DateTime LastUpdatedDate {get ;set;}						
					
		}							
			 			
		public class aspnet_Application							
		{
						    
			public String ApplicationName {get ;set;}						
							    
			public String LoweredApplicationName {get ;set;}						
						
			[Key]
			[Column(Order=0)]
						    
			public Guid ApplicationId {get ;set;}						
							    
			public String Description {get ;set;}						
					
		}							
			
		public partial class ynhnTransportManage:DbContext
		{
		 	
			public DbSet<Driver> Drivers {get;set;}
		 	
			public DbSet<aspnet_User> aspnet_Users {get;set;}
		 	
			public DbSet<aspnet_SchemaVersion> aspnet_SchemaVersions {get;set;}
		 	
			public DbSet<aspnet_Membership> aspnet_Membership {get;set;}
		 	
			public DbSet<UnitOfMeasure> UnitOfMeasures {get;set;}
		 	
			public DbSet<Vehicle> Vehicles {get;set;}
		 	
			public DbSet<aspnet_Profile> aspnet_Profile {get;set;}
		 	
			public DbSet<Transport> Transports {get;set;}
		 	
			public DbSet<TransportsLog> TransportsLog {get;set;}
		 	
			public DbSet<Card> Cards {get;set;}
		 	
			public DbSet<ekey> ekey {get;set;}
		 	
			public DbSet<aspnet_Role> aspnet_Roles {get;set;}
		 	
			public DbSet<Line> Lines {get;set;}
		 	
			public DbSet<aspnet_UsersInRole> aspnet_UsersInRoles {get;set;}
		 	
			public DbSet<aspnet_Sitemap> aspnet_Sitemaps {get;set;}
		 	
			public DbSet<aspnet_AuthorizationRule> aspnet_AuthorizationRules {get;set;}
		 	
			public DbSet<NameCode> NameCode {get;set;}
		 	
			public DbSet<aspnet_Path> aspnet_Paths {get;set;}
		 	
			public DbSet<Inventory> Inventory {get;set;}
		 	
			public DbSet<aspnet_PersonalizationAllUser> aspnet_PersonalizationAllUsers {get;set;}
		 	
			public DbSet<Dept> Depts {get;set;}
		 	
			public DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser {get;set;}
		 	
			public DbSet<adj_table> adj_table {get;set;}
		 	
			public DbSet<aspnet_WebEvent_Event> aspnet_WebEvent_Events {get;set;}
		 	
			public DbSet<aspnet_CustomProfile> aspnet_CustomProfile {get;set;}
		 	
			public DbSet<aspnet_Application> aspnet_Applications {get;set;}
		
		}
}