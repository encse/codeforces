﻿# Magic Spheres
# http://codeforces.com/problemset/problem/606/A
import sys
src = map(int, sys.stdin.readline().split())
dst = map(int, sys.stdin.readline().split())

while True:
	found = False
	for i in xrange(0,3):
		for k in xrange(0,3):
			if i!= k:
				if src[i] > dst[i] + 1 and src[k] < dst[k]:
					found = True
					d  = (src[i] -dst[i]) / 2
					d = min(d, dst[k]-src[k])
					src[i] -= d * 2
					src[k] += d
	if not found:
		break
					
ok = True
for i in xrange(0,3):
	if src[i] < dst[i]:
		ok = False

print "Yes" if ok else "No"