# DesignCrowdTechnicalChallenge

Calculates the number of weekdays between two dates.
	
	● Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
	
	● The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
	
	● If secondDate is equal to or before firstDate, return 0.
	
	

Calculate the number of business days between two dates.

	● Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
	
	● The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
	
	● If secondDate is equal to or before firstDate, return 0


Calculate the number of business days in between two dates (with more Holidays options). Current supported rules:

	● Public holidays on the same day, e.g. Anzac Day on 25th of April.
	
	● Public holidays on the same day, except when the days is on a weekend. e.g. New Year's Day on January 1st every year, unless that is a Saturday or Sunday, in this case, the holiday is on next Monday.
	
	● Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
