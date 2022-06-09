#! /usr/bin/awk -f

{
if (/Error Message:/) {
    found=1;getline;print "Failed!";print;
  }
  else if (/error/) {
    found=1;print;
  }
  else if (/Passed!/) {
    found=1;print;
  }
}; 
END { if(!found) print "Failed!" }