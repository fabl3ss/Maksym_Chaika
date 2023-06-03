Feature: Dropbox
	Dropbox API basics

	Scenario: Upload file to Dropbox
		Given I have a local file "file.txt"
		When I upload the file to Dropbox folder "/SDT"
		Then file "/SDT/file.txt" exist in Dropbox
		
	Scenario: Get file metadata from Dropbox
		Given there is a file "/SDT/file.txt" in Dropbox
		When I retrieve the metadata for the file
		Then file metadata should match with file

	Scenario: Delete file from Dropbox
		Given there is a file "/SDT/file.txt" in Dropbox
		When I delete the file from Dropbox
		Then the file does not exist in Dropbox