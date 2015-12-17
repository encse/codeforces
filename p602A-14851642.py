# Two Bases
# http://codeforces.com/problemset/problem/602/A
import sys
(len1, base1) = map(int, sys.stdin.readline().split())
digits1 = map(int, sys.stdin.readline().split())
(len2, base2) = map(int, sys.stdin.readline().split())
digits2 = map(int, sys.stdin.readline().split())


num1 = 0
for i in xrange(0, len(digits1)):
	num1 = num1 * base1 + digits1[i]

num2 = 0
for i in xrange(0, len(digits2)):
	num2 = num2 * base2 + digits2[i]

if num1 < num2: print '<'
if num1 > num2: print '>'
if num1 == num2: print '='